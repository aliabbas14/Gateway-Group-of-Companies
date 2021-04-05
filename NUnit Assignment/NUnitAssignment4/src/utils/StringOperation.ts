export class StringOperation{
    convertToUpper(str)
    {
        return str.toUpperCase();
    }

    convertToLower(str)
    {
        return str.toLowerCase();
    }

    firstcharacter(str)
    {
        return str.charAt(0);
    }

    concat(str1,str2)
    {
        return str1.concat(str2);
    }

    search(str,val)
    {
        return str.indexOf(val);
    }
}