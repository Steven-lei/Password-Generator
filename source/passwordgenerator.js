class PasswordGenerator
{
	constructor()
	{
		this.allsymbols = "!@#$%^&*()-=_+{}[]\|:;\"\',./<>?";
	}
	isValid(password,minLen,maxLen,withNumeric,withSymbols,withUpperCharacter,withLowerCharacter)
	{
		if(password.length < minLen || password.length > maxLen) return false;
		var bIncludeNumeric = false;
		var bIncludeSymbols = false;
		var bIncludeUpperCharacter = false;
		var bIncludeLowerCharacter = false;
		
		for(var i = 0; i< password.length; i++)
		{
			var charcode = password.charCodeAt(i);
			if(charcode >= "0".charCodeAt(0) && charcode <= "9".charCodeAt(0))
			{
				bIncludeNumeric = true;
			}
			if(charcode >= "A".charCodeAt(0) && charcode <= "Z".charCodeAt(0))
			{
				bIncludeUpperCharacter = true;
			}
			if(charcode >= "a".charCodeAt(0) && charcode <= "z".charCodeAt(0))
			{
				bIncludeLowerCharacter = true;	
			}
			if(this.allsymbols.includes(password[i]))
			{
				bIncludeSymbols = true;
			}
		}
	/*	
		if(withNumeric)
			if(-1 == password.Search("[0-9]") return false;
		if(withUpperCharacter)
			if(-1 == password.Search("[A-Z]") return false;
		if(withLowerCharacter)
			if(-1 == password.Search("[a-z]") return false;
	*/	
		if(bIncludeNumeric == withNumeric
			&& bIncludeSymbols == withSymbols
			&& bIncludeUpperCharacter == withUpperCharacter
			&& bIncludeLowerCharacter == withLowerCharacter)
			return true;
		return false;
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
		if(this.isValid(strpassword,minLen,maxLen,withNumeric,withSymbols,withUpperCharacter,withLowerCharacter))
		{
			console.log("password:",strpassword);
			return strpassword;
		}
		console.log(strpassword," is an invalid password");
		return this.createpassword(minLen,maxLen,withNumeric,withSymbols,withUpperCharacter,withLowerCharacter);
	}
}

module.exports = new PasswordGenerator(); 