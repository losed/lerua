
function clearVisitors()
{
var sql = "DELETE FROM visitors";
		$.ajax({
			url:"/_dbExecute?sql="+encodeURIComponent(sql),
			async:true,
			complete: function(ajax,stat){
				visitorsRefresh();
			}
		});
}
function insertVisitor(sCallback,fCallback)
{
var stat = $("#visitorsForm").find("select[name=status]").val(),
	num = $("#visitorsForm").find("input[name=number]").val();
	if(num.length < 1) {
		return fCallback();
	}
var sql = "INSERT INTO visitors (status,number) VALUES ('"+stat+"','"+num+"');";
							$.ajax({
								url:"/_dbExecute?sql="+encodeURIComponent(sql),
								async:false,
								complete: function(ajax,stat){
								
									if(parseInt(ajax.responseText)==0){
										return sCallback();
									}else{
										return fCallback();
									}
								}
							});	
}

function updateVisitor(sCallback,fCallback)
{
var stat = $("#visitorsForm").find("select[name=status]").val(),
	num = $("#visitorsForm").find("input[name=number]").val(),
	oldnum = $("#visitorsForm").find("input[name=oldNumber]").val(),
	doneSQL = " , done=datetime(CURRENT_TIMESTAMP, 'localtime') ";
if(stat==2){
	doneSQL = " , done=datetime(CURRENT_TIMESTAMP, 'localtime'),end=datetime(CURRENT_TIMESTAMP, 'localtime') ";
}else if(stat==1){
		if($("#visitorsForm").find("input[name=resetWaitTime]:checked").size()>0){
			doneSQL = " , done=datetime(CURRENT_TIMESTAMP, 'localtime'), start=datetime(CURRENT_TIMESTAMP, 'localtime') ";
		}	
}
var sql = "UPDATE visitors SET number='"+num+"',status='"+stat+"' "+doneSQL+" WHERE number='"+oldnum+"'";
		$.ajax({
			url:"/_dbExecute?sql="+encodeURIComponent(sql),
			async:false,
			complete: function(ajax,stat){
				if(parseInt(ajax.responseText)==0){
					return sCallback();
				}else{
					return fCallback();
				}
			}
		});
}
function visitorsRefresh()
{
var sql = "SELECT * FROM \
(\
SELECT *,\
	   (strftime('%s',datetime(CURRENT_TIMESTAMP, 'localtime')) - strftime('%s',start))/60 -(SELECT value FROM settings WHERE key='setExpiryTimeout') as late,\
       (strftime('%s',datetime(CURRENT_TIMESTAMP, 'localtime')) - strftime('%s',start))/60 as wait,\
       (strftime('%s',datetime(CURRENT_TIMESTAMP, 'localtime')) - strftime('%s',end))/60 as waitDone \
       FROM visitors WHERE status IN (0,1,2)\
) as foo WHERE status IN(0,1) OR status='2' AND waitDone<=(SELECT value FROM settings WHERE key='doneVisibleTimeout') ORDER BY done DESC, start DESC";
var results;
		$.ajax({
			url:"/_dbQuery?sql="+encodeURIComponent(sql),
			async:false,
			complete: function(ajax,stat){
				if(ajax.responseJSON!=undefined)
					results = ajax.responseJSON;
			}
		});
	var vlist = $("#visitorsList");
	config.needToRefresh = false;
	if(config.oldVlist == undefined || config.oldVlist.length!=results.length) {
		config.needToRefresh = true;
	} else {
		for(var i in results){
			if(config.oldVlist[i] == undefined){
				//console.log("not set oldVlist");
				config.needToRefresh = true;
				break;			
			}
			if(config.oldVlist[i].status != results[i].status){
				//console.log("changed status of ",i);
				config.needToRefresh = true;
				break;			
			}
			if(config.oldVlist[i].waitDone != results[i].waitDone){
				//console.log("changed waitDone of ",i);
				config.needToRefresh = true;
				break;			
			}
			if(config.oldVlist[i].wait != results[i].wait){
				//console.log("changed wait of ",i);
				config.needToRefresh = true;
				break;			
			}
		}
	}
	if(!config.needToRefresh) {
		//console.log("Nothing changed! Returning");
		return;
	}
	config.oldVlist = results;
	vlist.find("tbody").empty();
	for(i in results){
		var visitor = results[i];
		var visitor_status = "-",visitor_color='lightgray',visitor_wait=visitor.wait;
		visitor.statusT = visitor.status;
		if(visitor.late>=0 && visitor.status=='1' ){
			visitor.statusT = "LATE1";
		}
		if(config.visitors_status[visitor.statusT]!=undefined)
		{
			visitor_status = config.visitors_status[visitor.statusT].name;
			visitor_color = config.visitors_status[visitor.statusT].color;
		}

		if(visitor.status==2) visitor_wait = visitor.waitDone;
		var row=$('<tr><td  class=visitorNumber >'+visitor.number+'</td><td class=visitorStatus status="'+visitor.status+'">'+visitor_status+'</td><td>'+visitor_wait+'</td><td class="buttonHolder"></td></tr>').appendTo(vlist);
		//row.css({color:visitor_color});
		row.css({background:visitor_color});
		$('<div class="btn-group"><a class="active btn btn-info" id=doneVisitor title="Готов"><span class="glyphicon glyphicon-ok"></span></a><a class="active btn btn-success" id=editVisitor title="Изменить"><span class="glyphicon glyphicon-pencil"></span></a><a href="#" class="active btn btn-danger"  id=deleteVisitor title="Удалить"><span class="glyphicon glyphicon-remove"></span></a></div>').appendTo(row.find(".buttonHolder"));
    }
	vlist.find(".btn").click(function(){
		var id=$(this).parents("tr").find(".visitorNumber").text();
		var status = $(this).parents("tr").find(".visitorStatus").attr("status");
		var modalContainer = $("#visitorsForm");
		modalContainer.find(".alert").remove();
		modalContainer.find("input[name=number]").val(id);
		modalContainer.find("input[name=oldNumber]").val(id);
		modalContainer.find("select[name=status]").val(status);
		modalContainer.find("input[name=resetWaitTime]:checked").removeAttr("checked");
		var elemId = $(this).attr("id");
		switch(elemId){
			case 'doneVisitor':
				modalContainer.find("select[name=status]").val(2);
				break;
			case 'deleteVisitor':
				modalContainer.find("select[name=status]").val(-1);
				break;
			case 'editVisitor':
				break;
		}
		modalContainer.modal();
		setTimeout(function(){
				var inp = modalContainer.find("input[type=text],input[type=number],select").filter(":enabled").first();
				console.log(inp);
				inp.focus();
				$(document).on("keypress",function(event){
					console.log(event);
					if(event.charCode == 13){
						$(document).off("keypress");
						modalContainer.find("button.btn-primary").click();
					}
				});
			},1000)		
	});
}

$(function(){
	visitorsRefresh();
	config.visitorsRefreshInterval = false;
	$("#autoRefreshVisitorsList").change(function(){
		clearInterval(config.visitorsRefreshInterval);
		if($("#autoRefreshVisitorsList").prop("checked")){
			config.visitorsRefreshInterval = setInterval(function(){
				visitorsRefresh();
			},1000);
		}
	}).prop("checked",true).change();
	
	$("#clearVisitors").click(function(){
		if(confirm("Действие необратимо. Подтвердите"))clearVisitors();
	});
	$("#visitorsForm button.btn-primary").click(function(){
		var btn = $(this);
		//btn.html("Подождите...");
		updateVisitor(function(){
			insertVisitor(function(){
				$("<div class=\"alert alert-danger\">Не удалось сохранить...</div>").appendTo("#visitorsForm .modal-content")
				//$("#visitorsForm").modal('hide');
				},function(){
					$("#visitorsForm").modal('hide');
					visitorsRefresh();
				}
			)
		},function(){
			$("#visitorsForm").modal('hide');
			visitorsRefresh();
		});
	});

});
