var express = require('express'); 

var path = require('path'); 

var app = express(); 

  

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
app.get('/test',function(req,res){
	var strpassword="";
	for(var i='A';i<'D';i++)
	{
		strpassword=strpassword+"A";
		console.log(strpassword);
	}
});
app.get('/createpassword', function(req, res) {
	var result = {
			errmsg:"",
			passwordlist:[],
			configuration:{
					minLen:8,
					maxLen:12,
					withNumeric:true,	
					withSymbols: false,
					withUpperAlphabit:true,
					withLowerAlphabit:true,
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
	var withUpperCharacter = req.body.withUpperAlphabit == "on" ? true : false;
	var withLowerCharacter = req.body.withLowerAlphabit == "on" ? true : false;
	//console.log("createpassword:",minLen,maxLen, withNumeric,withSymbols,withUpperCharacter,withLowerCharacter);
	var passwordGenerator = require("./passwordgenerator");
	strpassword = passwordGenerator.createpassword(minLen, maxLen,withNumeric,withSymbols,withUpperCharacter,withLowerCharacter);
	var passwordlist = [];
	passwordlist.push(strpassword);
	var result={
		configuration:{
				minLen:minLen,
				maxLen:maxLen,
				withNumeric:withNumeric,	
				withSymbols: withSymbols,
				withUpperAlphabit:withUpperCharacter,
				withLowerAlphabit:withLowerCharacter
			},
		errmsg:"error",
		passwordlist:passwordlist,
		};
	res.render("createpassword",{result:result});
});


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

  

app.listen(process.env.port || 3000); 

console.log('Running at Port 3000'); 