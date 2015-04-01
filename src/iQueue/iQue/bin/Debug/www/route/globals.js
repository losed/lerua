var config = new Object();
config.visitors_status = {'0':{color:'rgb(253, 237, 91)',name:'Новый'},'1':{color:'rgb(253, 237, 91)',name:'Ожидает'},'LATE1':{color:'#FC7777',name:'Ожидает(задерж.)'},'2':{color:'lightgreen',name:'Готов'},'-1':{color:'lightgray',name:'Удален'}};
config.screen_types = {'0':{name:'для посетителей'},'1000':{name:'для сотрудников'},'-1':{name:'удалено'}};

try{
	$(function(){
	/************ДОБАВЛЕНИЕ ДОП.ПАРАМЕТРА во все запросы команды********************/
	$.ajaxSetup({
		beforeSend:function(a,b,c){
			if(this.url.indexOf("/_")==0){
				//this.url +="&sign="+getSignature(this.url);
				document.mCmd = this;
				//console.log("manageCOmmand detected");
			}
		}
	});
	
	/* loading adminPasswd from settings */
	var sql = "SELECT * FROM settings WHERE key='adminPasswd'";
	var admResults;
			$.ajax({
				url:"/_dbQuery?sql="+encodeURIComponent(sql),
				async:false,
				complete: function(ajax,stat){
					if(ajax.responseJSON!=undefined)
						admResults = ajax.responseJSON;
				}
			});
	if(admResults.length == 0) {
		config.adminPasswd = "leroyMerlin";
	} else {
		config.adminPasswd = admResults[0].value;
	}
	//console.log("config.adminPasswd",config.adminPasswd);
	/******************************************/		
	//bind открытие modalForm
	$(document).on('click',"a[data-toogle=modal]",function(){
		var id = $(this).attr("data-target");
		var modalContainer = $("#"+id);
		modalContainer.find(".alert").remove();
		modalContainer.modal({title:''})
		modalContainer.find("input[type=text],input[type=number]").val("");
		modalContainer.find("input[name=oldNumber]").val(id);
		modalContainer.find("select").each(function(){
			var defaultOpt = $(this).find("option[default]");
			if(defaultOpt.size()==1){
				$(this).val(defaultOpt.attr("value"));
				}
		});
		//timeout - затычка, но вроде работает - 2do:заменить на событие показа modal
		setTimeout(function(){
			var inp = modalContainer.find("input[type=text],input[type=number],select").first();
			inp.focus();
			
			$(document).on("keypress",function(event){
				//console.log(event);
				if(event.charCode == 13 || event.keyCode==13){
					$(document).off("keypress");
					modalContainer.find("button.btn-primary").click();
				}
			});
		},1000)
	});

	//menu
	$("#menuPanel .list-group-item").click(function(){
		$(".mainPanel").hide('fade');
		$("#menuPanel .list-group-item").removeClass('active');
		var entity = $(this).addClass("active").attr("id").replace("Button","");
		if((entity == "screens" || entity == "settings") && (config.enteredPassword == undefined || config.enteredPassword!=config.adminPasswd)){
			config.enteredPassword = prompt("Введите пароль администратора");
			if(config.enteredPassword!=config.adminPasswd) {
				if(config.enteredPassword!=null)alert("Неверный пароль");
				return;
			}
		}
		var tSort = $("#"+entity+"List");
		var panel = $("#"+entity+"Panel").show('fade');
		str= entity+'Refresh()';
		//console.log("menu", entity);
		eval(str);
		
	});
	//softwareVersion
	config.softwareVersion = "1.0.0.0";
	$.ajax({
				url:"/_softwareVersion",
				async:false,
				complete: function(ajax,stat){
				//console.log(ajax,stat);
					if(ajax.responseJSON!=undefined)
						config.software = ajax.responseJSON;
						$("#softwareVersion").html(config.software.product+" <sup>"+config.software.version+"</sup>");
				}
			});
			
	var url = parseUri(document.location.href);
	if(url.queryKey != undefined && url.queryKey.entity != undefined){
		$("#"+url.queryKey.entity+"Button").click();	
	}
	});
}
catch(ex){
window.location.href=window.location.href;
}
