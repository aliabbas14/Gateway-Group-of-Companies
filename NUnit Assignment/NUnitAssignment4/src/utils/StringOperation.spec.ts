import { StringOperation } from "./StringOperation";

describe('String Testing', () => {

    // Using mock instance of util class
    let str : StringOperation;

    beforeEach(() => {
        str=new StringOperation();
    });
    afterEach(()=>{
        str=null;
    });

    it('Uppercase',()=>{

        // Arrange
        let inputString="abc";
        // Act
        let result=str.convertToUpper(inputString);
        // Assert
        expect(result=="ABC").toBeTrue();
    });

    it('Lowercase',()=>{

        // Arrange
        let inputString="ABC";
        // Act
        let result=str.convertToLower(inputString);
        // Assert
        expect(result=="abc").toBeTrue();
    });

    it('FirstChar',()=>{

        // Arrange
        let inputString="xyz";
        // Act
        let result=str.firstcharacter(inputString);
        // Assert
        expect(result=="x").toBeTrue();
    });

    it('Concat',()=>{

        // Arrange
        let inputString1="abc";
        let inputString2="xyz";
        // Act
        let result=str.concat(inputString1,inputString2);
        // Assert
        expect(result=="abcxyz").toBeTrue();
    });

    it('Search',()=>{

        // Arrange
        let inputString1="abc";
        let inputString2="abc";
        // Act
        let result=str.search(inputString1,inputString2);
        // Assert
        expect(result=="0").toBeTrue();
    });


});