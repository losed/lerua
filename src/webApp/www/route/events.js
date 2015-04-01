
function clearEvents()
{
var sql = "DELETE FROM events";
		$.ajax({
			url:"/_dbExecute?sql="+encodeURIComponent(sql),
			async:true,
			complete: function(ajax,stat){
				eventsRefresh();
			}
		});
}

function eventsRefresh()
{
var sql = "SELECT * FROM events ORDER BY date";
var results;
		$.ajax({
			url:"/_dbQuery?sql="+encodeURIComponent(sql),
			async:false,
			complete: function(ajax,stat){
				if(ajax.responseJSON!=undefined)
					results = ajax.responseJSON;
			}
		});
	var vlist = $("#eventsList tbody");
	vlist.html("");
	//var eventsCsv = "Дата;Талон;Описание события;\n"
	var eventsCsv = "<table><thead><tr><th>Дата и время</th><Th>Талон</th><th>Описание события</th></tr></thead><Tbody>"
	for(i in results){
		var event = results[i];
		var row=$('<tr><td  class=eventDate >'+event.date+'</td><td class=visitorStatus >'+event.visitor+'</td><td>'+event.action+'</td></tr>').appendTo(vlist);
		//eventsCsv += event.date+";"+event.visitor+";"+event.action+";\n"
		eventsCsv += "<tr><td>"+event.date+"</td><td>"+event.visitor+"</td><td>"+event.action+"</td></tr>"
		//row.css({color:visitor_color});
		
    }
	eventsCsv+="</tbody></table>";
	//$("#saveEvents").attr("href",'data:text/csv;charset=utf-8,' + encodeURIComponent(eventsCsv)).attr("download","Журнал "+(new Date()).toDateString()+".csv");
	$(".saveEvents").attr("href",'data:application/vnd.ms-excel; charset=UTF-8,' + encodeURIComponent(eventsCsv)).attr("download","Журнал iQueue.xls");
		
}

function createReport()
{
	var allSql = "SELECT number, start, end,(strftime('%s',end) - strftime('%s',start)) as serveTime FROM visitors WHERE status IN (2) order by start";
	var allResults;
		$.ajax({
			url:"/_dbQuery?sql="+encodeURIComponent(allSql),
			async:false,
			complete: function(ajax,stat){
				if(ajax.responseJSON!=undefined)
					allResults = ajax.responseJSON;
			}
		});
		
	var agSql = "SELECT min(serveTime) as minimum,max(serveTime) as maximum, avg(serveTime) as average, strftime('%s',max(end)) - strftime('%s',min(start)) as period, min(start) as start, max(end) as end,count(*) as cnt FROM ( SELECT number, start, end, (strftime('%s',end) - strftime('%s',start)) as serveTime FROM visitors WHERE status IN (2)) as foo";
	var agResults;
	$.ajax({
		url:"/_dbQuery?sql="+encodeURIComponent(agSql),
		async:false,
		complete: function(ajax,stat){
			if(ajax.responseJSON!=undefined)
				agResults = ajax.responseJSON;
		}
	});
	console.log(agResults);
	var exportCsv = "";
	if(agResults.length!=1) {
		alert("Некорректные данные! Отчет пуст!");
		return;
	}
	var ag = agResults[0];
/*	exportCsv+="Сводный отчет по обслуживанию клиентов в системе iQueue;\r\n";
	exportCsv+="Начало отчетного периода;"+ag.start+";\r\n";
	exportCsv+="Окончание отчетного периода;"+ag.end+";\r\n";
	exportCsv+="Длительность периода, секунд;"+ag.period+";\r\n";
	exportCsv+="Всего обслужено клиентов;"+ag.cnt+";\r\n";
	exportCsv+="Среднее время обслуживания;"+ag.average+";\r\n";
	exportCsv+="Минимальное время обслуживания;"+ag.minimum+";\r\n";
	exportCsv+="Максимальное время обслуживания;"+ag.maximum+";\r\n";
	exportCsv+=";\r\n";
	exportCsv+="Полный список клиентов по номерам талонов представлен ниже;\r\n";
	exportCsv+="Номер талона;Начало обслуживания;Окончание обслуживания;Продолжительность обслуживания;\r\n";
	for(var i in allResults){
		var client = allResults[i];
		exportCsv+=client.number+";"+client.start+";"+client.end+";"+client.serveTime+";\r\n";
	}
	*/
	exportCsv+="<Table><tr><td style='border:2px solid yellow;'><Table><tr><td colspan=4  style='font-size:18px;font-weight:bold;'>Сводный отчет по обслуживанию клиентов в системе iQueue</td></tr>";
	exportCsv+="<tr><td colspan=3>Начало отчетного периода</td><td style='font-size:14px;font-weight:bold;'>"+ag.start+"</td></tr>";
	exportCsv+="<tr><td colspan=3>Окончание отчетного периода</td><td style='font-size:14px;font-weight:bold;'>"+ag.end+"</td></tr>";
	exportCsv+="<tr><td colspan=3>Длительность периода, секунд</td><td style='font-size:14px;font-weight:bold;'>"+ag.period+"</td></tr>";
	exportCsv+="<tr><td colspan=3>Количество обслуженных клиентов</td><td style='font-size:14px;font-weight:bold;'>"+ag.cnt+"</td></tr>";
	exportCsv+="<tr><td colspan=3>Среднее время обслуживания, секунд</td><td style='font-size:14px;font-weight:bold;'>"+ag.average+"</td></tr>";
	exportCsv+="<tr><td colspan=3>Минимальное время обслуживания, секунд</td><td style='font-size:14px;font-weight:bold;'>"+ag.minimum+"</td></tr>";
	exportCsv+="<tr><td colspan=3>Максимальное время обслуживания, секунд</td><td style='font-size:14px;font-weight:bold;'>"+ag.maximum+"</td></tr>";
	exportCsv+="<tr><td colspan=4 style='border:1px dotted red;'><i>Полный список клиентов по номерам талонов представлен ниже</i></td></tr><tr><td colspan=4>&nbsp;</td></tr></table>";
	exportCsv+="<table style='border:1px solid blue;'><thead  style='font-size:14px;font-weight:bold;'><tr><th>Номер талона</th><th>Начало обслуживания</th><th>Окончание обслуживания</th><th>Продолжительность обслуживания, секунд</th></tr></thead>";
	exportCsv+="<tbody style='font-size:13px;font-weight:normal;'>";
	for(var i in allResults){
		var client = allResults[i];
		console.log(client);
		exportCsv+="<tr><td>"+client.number+"</td><td>"+client.start+"</td><td>"+client.end+"</td><td>"+client.serveTime+"</td></tr>";
	}	
	exportCsv+="</tbody></table></td></tr></table>";
		//console.log(exportCsv);
	$(".createReport").attr("href",'data:application/vnd.ms-excel; charset=UTF-8,' + encodeURIComponent(exportCsv)).attr("download","Отчет iQueue.xls");
}
$(function(){
	eventsRefresh();
	$(".createReport").click(function(){
		createReport();
	});
	$(".clearEvents").click(function(){
		if(confirm("Действие необратимо. Подтвердите"))clearEvents();
	});
});
