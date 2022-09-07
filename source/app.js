// use npm install express to install this module first
var express = require('express'); 

var path = require('path'); 

var app = express(); 

// use npm install --save cookie-parser to install this module first
const cookieParser = require("cookie-parser");
app.use(cookieParser());

//var mysql = require('mysql'); 

//var connection = require('./dbConfig'); 

  

//ejs templete  

app.set('view engine', 'ejs');  

  

//using app.use to serve up static CSS files in public/assets/ folder when /public link is called in ejs files 

// app.use("/route", express.static("foldername")); 

app.use('/public', express.static('public')); 

  

// this is for read POST data  

app.use(express.json());  

  

app.use(express.urlencoded({  

    extended: true  

    }));  



//All routing start here..   

  
/*
// index page  
app.get('/',function(req,res){
	res.send("hello world");
});*/

app.get('/', function(req, res){  

	res.render("index");  

});  
app.post('/',function(req,res){
	console.log("post");
	console.log(req.body);
	res.send("post of index page");
});
app.all('/test',function(req,res){
	var strpassword="";
	for(var i='1';i<'9';i++)
	{
		strpassword=strpassword+i;
		console.log(strpassword);
	}
	res.send(strpassword);
});
app.get('/createpassword', function(req, res) {
	console.log(req.cookies);
	//console.log(req.cookies.minLen);
	var result = {
			errmsg:"",
			passwordlist:[],
			configuration:{
					minLen:req.cookies.minLen || 8,
					maxLen:req.cookies.maxLen || 12,
					withNumeric:((req.cookies.withNumeric || "true")== "true" ? true : false),	
					// if the cookie is not existed, give it a default value. if existed use it
					withSymbols: ((req.cookies.withSymbols || "false")== "true" ? true : false),
					withUpperAlphabit:((req.cookies.withUpperAlphabit || "false") == "true" ? true : false),
					withLowerAlphabit:((req.cookies.withLowerAlphabit || "true")== "true" ? true : false),
			},

		};

	console.log(result);
	res.render("createpassword",{result:result});
}); 


app.post('/createpassword', function(req,res){
	var minLen = parseInt(req.body.minLen);
	var maxLen = parseInt(req.body.maxLen);
	var withNumeric = req.body.withNumeric == "on" ? true : false;
	var withSymbols = req.body.withSymbols == "on" ? true : false;
	var withUpperAlphabit = req.body.withUpperAlphabit == "on" ? true : false;
	var withLowerAlphabit = req.body.withLowerAlphabit == "on" ? true : false;
	
	var passwordlist = [];
	//check whether the parameters are valid
	var error = "";
	if(minLen <= 0)
		error = "the length of password should greater than 0";
	if(maxLen >32)
		error = "the length of password should less or equal than 32";
	if(minLen > maxLen)
		error = "minLen should less than maxLen";
	if(withNumeric == false && 
		withSymbols == false && 
		withUpperAlphabit == false && 
		withLowerAlphabit == false)
		error = "a password should inlude one of the numbers,symbols or characters";
	
	if(error != "")
	{
		var result={
		configuration:{
				minLen:minLen,
				maxLen:maxLen,
				withNumeric:withNumeric,	
				withSymbols: withSymbols,
				withUpperAlphabit:withUpperAlphabit,
				withLowerAlphabit:withLowerAlphabit
			},
		errmsg:error,
		passwordlist:passwordlist,
		};

		res.render("createpassword",{result:result});
		return;
	}
	//save these parameters to cookies
	//set cookie expire after 1 year 
	var date = new Date();
	date.setDate(date.getDate()+365);
	var cookieops = {expires: date,secure:true,httpOnly:true,sameSite:'lax'};
	res.cookie("minLen", minLen,cookieops);
	res.cookie("maxLen", maxLen,cookieops);
	res.cookie("withNumeric", withNumeric,cookieops);
	res.cookie("withSymbols", withSymbols,cookieops);
	res.cookie("withUpperAlphabit",withUpperAlphabit,cookieops);
	res.cookie("withLowerAlphabit",withLowerAlphabit,cookieops);
	
	//console.log("createpassword:",minLen,maxLen, withNumeric,withSymbols,withUpperAlphabit,withLowerAlphabit);
	var passwordGenerator = require("./passwordgenerator");
	strpassword = passwordGenerator.createpassword(minLen, maxLen,withNumeric,withSymbols,withUpperAlphabit,withLowerAlphabit);
	passwordlist.push(strpassword);
	var result={
		configuration:{
				minLen:minLen,
				maxLen:maxLen,
				withNumeric:withNumeric,	
				withSymbols: withSymbols,
				withUpperAlphabit:withUpperAlphabit,
				withLowerAlphabit:withLowerAlphabit
			},
		errmsg:"",
		passwordlist:passwordlist,
		};

	res.render("createpassword",{result:result});
});


//testing code to check whether cookie is ok or not 
app.all('/setcookie',function(req,res){
	res.cookie("set cookiedata","this is my cookie");
	res.send("set cookies");
});
app.all('/getcookie',function(req,res){
	console.log(req.cookies);
	res.send(req.cookies);
});
app.all('/clearcookie',function(req,res){
	res.clearCookie();
	res.send("cookie cleared");
});

// this page can be used to test the creating function by Maribeth
app.all('/testcreatepassword', function(req,res){
	var minLen = 8;
	var maxLen = 20;
	var withNumeric = true;
	var withSymbols = false;
	var withUpperAlphabit = true;
	var withLowerAlphabit = true;
	var passwordGenerator = require("./passwordgenerator");
	strpassword = passwordGenerator.createpassword(minLen, maxLen,withNumeric,withSymbols,withUpperAlphabit,withLowerAlphabit);

	res.send(strpassword);
});

//error handler
app.use(function(err, req, res, next) {
  //takeover the default error handling in order to avoid the 
  console.error(err.stack);
  res.render("error",{errmsg:"Error founded"});
  res.end();
  //res.status(500).send('something wrong or page not founded');
});

app.use(function(req,res,next){
  //console.error(err.stack);
  res.render("error",{errmsg:"Error founded:Page not exists"});
  res.end();
  next();
});  



/*
//dbRead page displays the retrieved data in an HTML table   

app.get('/dbRead', function(req, res){  

    connection.query("SELECT * FROM users", function (err, result) {  

        if (err) throw err;  

        console.log(result);  

res.render('dbRead', { title: 'xyz', userData: result});  

        });  

    });  

 

//add data	 

app.post('/', function(req, res) { 

var abcd = req.body.id; 

var bcde = req.body.name; 

var xyz = req.body.email; 

console.log(req.body); 

var sql = `INSERT users (id, name, email) VALUES ("${abcd}", "${bcde}", "${xyz}")`; 

connection.query(sql, function(err, result) { 

if (err) throw err; 

console.log("1 record inserted"); 

}); 

return res.render('index', {errormessage: 'insert data'}); 

}); 

  

//delete data 

app.post('/delete', function(req, res) { 

var abcd = req.body.id; 

console.log(req.body.id); 

var sql = `DELETE FROM users WHERE id="${abcd}"`; 

connection.query(sql, function(err, result) { 

if (err) throw err; 

console.log("1 record deleted"); 

}); 

return res.render('index', {errormessage: 'deeta'}); 

}); 

*/  

app.listen(process.env.port || 3000); 

console.log('Running at Port 3000'); 