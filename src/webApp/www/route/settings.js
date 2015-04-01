function updateSetting(sCallback,fCallback)
{
var value = $("#settingsForm").find("input[name=value]").val(),
	key = $("#settingsForm").find("input[name=key]").val();

var sql = "UPDATE settings SET value='"+value+"'  WHERE key='"+key+"'";
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
function settingsRefresh()
{
var sql = "SELECT * FROM settings ORDER BY id";
var results;
		$.ajax({
			url:"/_dbQuery?sql="+encodeURIComponent(sql),
			async:false,
			complete: function(ajax,stat){
				if(ajax.responseJSON!=undefined)
					results = ajax.responseJSON;
			}
		});
	var vlist = $("#settingsList");
	vlist.find("tbody").empty();
	for(i in results){
		var setting = results[i];
		setting.behavior_txt = "";
		var row=$('<tr><td >'+setting.id+'</td><td>'+setting.name+'</td><td>'+setting.value+'</td><td class="buttonHolder"></td></tr>').appendTo(vlist);
		row.data(setting);
		//row.css({color:setting_color});
		$('<div class="btn-group"><a class="active btn btn-success" id=editSetting title="Изменить"><span class="glyphicon glyphicon-pencil"></span></a></div>').appendTo(row.find(".buttonHolder"));
    }
	vlist.find(".btn").click(function(){
		var row = $(this).parents("tr");
		var data = row.data();		
		var modalContainer = $("#settingsForm")
		modalContainer.find("input,select").each(function(){
			var name = $(this).attr("name");
			$(this).val(data[name]);
			if(name == 'value')
				{
				$(this).attr("type",data["type"]);
				}
		});
		var elemId = $(this).attr("id");
		switch(elemId){
			case 'deleteSetting':
				//deleteSetting(id);
				break;
			case 'editSetting':
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
	settingsRefresh();
	$("#clearSettings").click(function(){
		if(confirm("Действие необратимо. Подтвердите"))clearSettings();
	});
	$("#settingsForm button.btn-primary").click(function(){
		var btn = $(this);
		//btn.html("Подождите...");
		updateSetting(function(){
			$("<div class=\"alert alert-danger\">Не удалось сохранить...</div>").appendTo("#settingsForm .modal-content")
		},function(){
			$("#settingsForm").modal('hide');
			settingsRefresh();
		});
	});

});
