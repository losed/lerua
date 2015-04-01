
function clearScreens()
{
var sql = "DELETE FROM screens";
		$.ajax({
			url:"/_dbExecute?sql="+encodeURIComponent(sql),
			async:true,
			complete: function(ajax,stat){
				screensRefresh();
			}
		});
}

function deleteScreen(id)
{
var sql = "DELETE FROM screens WHERE id='"+id+"'";
		$.ajax({
			url:"/_dbExecute?sql="+encodeURIComponent(sql),
			async:true,
			complete: function(ajax,stat){
				screensRefresh();
			}
		});
}
function insertScreen(sCallback,fCallback)
{
var behavior = $("#screensForm").find("select[name=behavior]").val(),
	ip = $("#screensForm").find("input[name=ip]").val(),
	id = $("#screensForm").find("input[name=id]").val(),
	name = $("#screensForm").find("input[name=name]").val(),
	port = $("#screensForm").find("input[name=port]").val(),
	width = $("#screensForm").find("input[name=width]").val(),
	height = $("#screensForm").find("input[name=height]").val(),
	name = $("#screensForm").find("input[name=name]").val();
	
var sql = "INSERT INTO screens (id,ip,name,behavior,port,width,height) VALUES ('"+id+"','"+ip+"','"+name+"','"+behavior+"','"+port+"','"+width+"','"+height+"');";
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

function updateScreen(sCallback,fCallback)
{
var behavior = $("#screensForm").find("select[name=behavior]").val(),
	ip = $("#screensForm").find("input[name=ip]").val(),
	id = $("#screensForm").find("input[name=id]").val(),
	oldId = $("#screensForm").find("input[name=oldId]").val(),
	name = $("#screensForm").find("input[name=name]").val(),
	port = $("#screensForm").find("input[name=port]").val(),
	width = $("#screensForm").find("input[name=width]").val(),
	height = $("#screensForm").find("input[name=height]").val(),
	name = $("#screensForm").find("input[name=name]").val();

var sql = "UPDATE screens SET id='"+id+"',ip='"+ip+"',name='"+name+"', behavior='"+behavior+"', port='"+port+"', width='"+width+"', height='"+height+"'  WHERE id='"+oldId+"'";
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
function screensRefresh()
{
var sql = "SELECT * FROM screens ORDER BY id";
var results;
		$.ajax({
			url:"/_dbQuery?sql="+encodeURIComponent(sql),
			async:false,
			complete: function(ajax,stat){
				if(ajax.responseJSON!=undefined)
					results = ajax.responseJSON;
			}
		});
	var vlist = $("#screensList");
	vlist.find("tbody").empty();
	
	for(i in results){
		var screen = results[i];
		screen.behavior_txt = config.screen_types[screen.behavior].name
		screen.oldId = screen.id
		var row=$('<tr><td  class=screenNumber>'+screen.id+'</td><td class=screenName>'+screen.name+'</td><td class=screenBehavior data="'+screen.behavior+'" >'+screen.behavior_txt+'</td><td class="screenIP">'+screen.ip+'</td><td class="buttonHolder"></td></tr>').appendTo(vlist);
		row.data(screen);
		//row.css({color:screen_color});
		$('<div class="btn-group"><a class="active btn btn-success" id=editScreen title="Изменить"><span class="glyphicon glyphicon-pencil"></span></a><a href="#" class="active btn btn-danger"  id=deleteScreen title="Удалить"><span class="glyphicon glyphicon-remove"></span></a></div>').appendTo(row.find(".buttonHolder"));
    }
	vlist.find(".btn").click(function(){
		var id=$(this).parents("tr").find(".screenNumber").text();
		var ip=$(this).parents("tr").find(".screenIP").text();
		var behavior=$(this).parents("tr").find(".screenBehavior").attr("data");
		var name = $(this).parents("tr").find(".screenName").text();
		
		var row = $(this).parents("tr");
		var data = row.data();
		var modalContainer = $("#screensForm")
		modalContainer.find(".alert").remove();
		modalContainer.find("input,select").each(function(){
			var name = $(this).attr("name");
			$(this).val(data[name]);
		});/*[name=id]").val(id);
		$("#screensForm").find("input[name=ip]").val(ip);
		$("#screensForm").find("input[name=name]").val(name);
		$("#screensForm").find("select[name=behavior]").val(behavior);
		*/
		var elemId = $(this).attr("id");
		switch(elemId){
			case 'deleteScreen':
				if(confirm("Действие необратимо. Подтвердите"))
					deleteScreen(id);
					else
					return;
				break;
			case 'editScreen':
				
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
				break;
		}
		
	});
}

$(function(){
	screensRefresh();
	$("#clearScreens").click(function(){
		if(confirm("Действие необратимо. Подтвердите"))clearScreens();
	});
	$("#screensForm button.btn-primary").click(function(){
		var btn = $(this);
		//btn.html("Подождите...");
		updateScreen(function(){
			insertScreen(function(){
				$("<div class=\"alert alert-danger\">Не удалось сохранить...</div>").appendTo("#screensForm .modal-content")
				//$("#screensForm").modal('hide');
				},function(){
					$("#screensForm").modal('hide');
					screensRefresh();
				}
			)
		},function(){
			$("#screensForm").modal('hide');
			screensRefresh();
		});
	});

});
