/********************file utils.js********************************/ 
/*		Contains some utils what are absent by some reasons 
		in native JS in browsers or their use seemed too difficult
		to some usual PHP-developer								 */
/* Function list:
	string encode64(string);
	string decode64(string);
	int getRandomInt(int min, int max);
	numeric(14,2) round(float val);
	bool in_array(obj,arr);
	numeric random_generator(digits);
	object URI parseUri (str) ;
		URI has keys:
			-queryKey: Object in which keys represents GET or SET urlencoded params (as sent to HTTP-server)
Simple example:			
	parseUri("proto://user:pass@host.zone:8888/_dbQuery?param1=val1&param2[a]=val2&params2[b]=val3#ANCHOR_CODE")
	returns 
	Object {
		anchor: "ANCHOR_CODE"
		authority: "user:pass@host.zone:8888"
		directory: "/_dbQuery"
		file: ""
		host: "host.zone"
		password: "pass"
		path: "/_dbQuery"
		port: "8888"
		protocol: "proto"
		query: "param1=val1&param2[a]=val2&params2[b]=val3"
		queryKey: Object
		relative: "/_dbQuery?param1=val1&param2[a]=val2&params2[b]=val3#ANCHOR_CODE"
		source: "proto://user:pass@host.zone:8888/_dbQuery?param1=val1&param2[a]=val2&params2[b]=val3#ANCHOR_CODE"
		user: "user"
		userInfo: "user:pass"
		__proto__: Object			
	}
	
				
Global values: (set in this source-file)
	parseUri.options	- object has keys
				0: "source"
				1: "protocol"
				2: "authority"
				3: "userInfo"
				4: "user"
				5: "password"
				6: "host"
				7: "port"
				8: "relative"
				9: "path"
				10: "directory"
				11: "file"
				12: "query"
				13: "anchor"
	

-*
/*****************authored by loSed*******************************/
/*****distributed under GPL-license or similiar conditions********/ 
/****************** Copyright&copy; 2014**************************/
/**************E-mail contact: 0977@ngs.ru************************/
/*****************************************************************/
function encode64(input)
{
	var output = new String();
	var chr1, chr2, chr3;
	var enc1, enc2, enc3, enc4;
	var i = 0;

	while (i < input.length) 
    {
		chr1 = input.charCodeAt(i++);
		chr2 = input.charCodeAt(i++);
		chr3 = input.charCodeAt(i++);

		enc1 = chr1 >> 2;
		enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
		enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
		enc4 = chr3 & 63;
		if (isNaN(chr2))
        {
			enc3 = enc4 = 64;
		} else if (isNaN(chr3)) 
        {
			enc4 = 64;
		}
		output+=(current['keyStr'].charAt(enc1) + current['keyStr'].charAt(enc2) + current['keyStr'].charAt(enc3) + current['keyStr'].charAt(enc4));
   }
   return output.toString();
}

function decode64(input)
{
	var output = new String();
	var chr1, chr2, chr3;
	var enc1, enc2, enc3, enc4;
	var i = 0;

	// remove all characters that are not A-Z, a-z, 0-9, +, /, or =
	input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

	while (i < input.length) {
		enc1 = current['keyStr'].indexOf(input.charAt(i++));
		enc2 = current['keyStr'].indexOf(input.charAt(i++));
		enc3 = current['keyStr'].indexOf(input.charAt(i++));
		enc4 = current['keyStr'].indexOf(input.charAt(i++));

		chr1 = (enc1 << 2) | (enc2 >> 4);
		chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
		chr3 = ((enc3 & 3) << 6) | enc4;

		output+=(String.fromCharCode(chr1));

		if (enc3 != 64) 
        {
			output+=(String.fromCharCode(chr2));
		}
		if (enc4 != 64)
        {
			output+=(String.fromCharCode(chr3));
		}
	}
	return output.toString();
}

function getRandomInt(min, max)
{
  return Math.floor(Math.random() * (max - min + 1)) + min;

}

function round(var1)
{
    res=Math.round(var1*100)/100. ;
    return res;
}

function in_array(obj,arr)
{
    for(i in arr)
	{
        if(arr[i]==obj)
            return true;
	}
return false;
}

function random_generator(digits)
{
    st="1";
    fi="9";
    for(i=0;i<digits-1;i++)
    {
        st+="0";
        fi+="9";
    }
    m = parseInt(st);
    n = parseInt(fi);
    return Math.floor( Math.random() * (n - m + 1) ) + m;
}

function parseUri (str) 
{
	var	o   = parseUri.options,
    m   = o.parser[o.strictMode ? "strict" : "loose"].exec(str),
    uri = {},
    i   = 14;
	while (i--) uri[o.key[i]] = m[i] || "";
	uri[o.q.name] = {};
	uri[o.key[12]].replace(o.q.parser, function ($0, $1, $2)
    {
		if ($1) uri[o.q.name][$1] = $2;
	});
	return uri;
};

parseUri.options = 
{
	strictMode: false,
	key: ["source","protocol","authority","userInfo","user","password","host","port","relative","path","directory","file","query","anchor"],
	q:   
    {
		name:   "queryKey",
		parser: /(?:^|&)([^&=]*)=?([^&]*)/g
	},
	parser:
    {
		strict: /^(?:([^:\/?#]+):)?(?:\/\/((?:(([^:@]*)(?::([^:@]*))?)?@)?([^:\/?#]*)(?::(\d*))?))?((((?:[^?#\/]*\/)*)([^?#]*))(?:\?([^#]*))?(?:#(.*))?)/,
		loose:  /^(?:(?![^:@]+:[^:@\/]*@)([^:\/?#.]+):)?(?:\/\/)?((?:(([^:@]*)(?::([^:@]*))?)?@)?([^:\/?#]*)(?::(\d*))?)(((\/(?:[^?#](?![^?#\/]*\.[^?#\/.]+(?:[?#]|$)))*\/?)?([^?#\/]*))(?:\?([^#]*))?(?:#(.*))?)/
	}
};