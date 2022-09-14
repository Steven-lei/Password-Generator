class PasswordGenerator
{
	constructor()
	{
		this.allsymbols = "!@#$%^&*()-=_+{}[]\|:;\"\',./<>?";
	}
	
	createpassword(minLen,maxLen,withNumeric,withSymbols,withUpperCharacter,withLowerCharacter)
	{
		var allcharacters = [];
		if(withNumeric)
		{
			for(var i = '0';i <= '9';i++)
				allcharacters.push(i);
		}

		if(withSymbols)
		{
			for(var i = 0;i<this.allsymbols.length; i++)
			{
				allcharacters.push(this.allsymbols[i]);
			}
		}
		if(withUpperCharacter)
		{
			for(var c="A".charCodeAt(0); c <= "Z".charCodeAt(0); c++)
			{
				allcharacters.push(String.fromCharCode(c));
				//console.log(String.fromCharCode(c));
			}	
			
		}
		if(withLowerCharacter)
		{
			for(var c="a".charCodeAt(0); c <= "z".charCodeAt(0); c++)
				allcharacters.push(String.fromCharCode(c));
		}
		if(allcharacters.length <=0){
			console.log("invalid parameters for create password");
			return "";
		}
		var len = minLen + Math.floor(Math.random() * (maxLen-minLen));
		var strpassword="";
		console.log("to create a password of",len);
		for(var i=0; i<len; i++)
		{
			var pos = Math.floor(Math.random()*allcharacters.length);
			strpassword = strpassword + allcharacters[pos];
		}
		return strpassword;
	}
}

module.exports = new PasswordGenerator();

	                   
