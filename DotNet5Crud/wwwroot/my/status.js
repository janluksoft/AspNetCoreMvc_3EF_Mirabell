
function jTypeTxtToElementId(xIdElement, xTxtNew){
    const parent = document.getElementById(xIdElement);
    if (parent) {
        parent.textContent = xTxtNew;
    }
}

///============ 4 MAIN Function =============================
// Operacje dotyczą elementu html <Select> (DropDown) zdefiniowanego np. tak:
//
//   <select id="iselect-box">
//     <option value="s1">Orange</option>
//     <option value="s2">Red</option>
//     <option value="s3">Blue</option>
//   </select>

//---- funkcja 1: [jDropDown_TypeNewRowsToSelect]
// Do elementu html <Select> (DropDown) o [id= xTxtIdElementSelect]
// wpisywane są pozycje string[] z tabeli: [xTabTxt], czyli jest to napełnianie DropDown
// np. Uses: [onclick="jDropDown_TypeNewRowsToSelect('iselect-box',['jeden','dwa','trzy'])"]
function jDropDown_TypeNewRowsToSelect(xTxtIdElementSelect, xTabTxt) {

    let cDropDownObject = new CDropDownOperations(xTxtIdElementSelect); //class

    //example: xTabTxt = ['five','four','three','two','one'];
    cDropDownObject.addNewRowsToSelect(xTabTxt);
}

//---- funkcja 2: [jDropDown_ReadActualSelect]
// Z elementu html <Select> (DropDown) o [id= xTxtIdElementSelect]
// czytany jest aktualnie wybrany string, Czyli jest to zwykle czytanie DropDown
// np. Uses: [onclick="jDropDown_ReadActualSelect('iselect-box')"]
function jDropDown_ReadActualSelect(xTxtIdElementSelect) {

    let cDropDownObject = new CDropDownOperations(xTxtIdElementSelect); //class
		//alert("Start2");

    let aTxtActualChoice = cDropDownObject.readActualPopUp();
		//alert("Actual choice in the ("+ xTxtIdElementSelect+ ") element is: ("+ aTxtActualChoice+")");
    return(aTxtActualChoice);
}

//---- funkcja 3: [jDropDown_TypeSpecjalRowsToSelect]
// Gdzieś zewnętrznie ustawiony jest [Status] Task-u na np. [NEW]. Tego statusu nie można zmienić
// na dowolny, ale na kilka innych zdefiniowanych w klasie [CStatus_HardwareDirect] 
// Zatem podaje się w argumencie np. [xTxtActualStatus = 'NEW'] i wtedy w elementcie html <Select> 
// (DropDown) o [id= xTxtIdElementSelect] funkcja zapisze tylko 
// 2 możliwe statusy: 'IN PROGRESS','CANCELED' 
// np. Uses: [onclick="jDropDown_TypeSpecjalRowsToSelect('iselect-box','NEW')"]
function jDropDown_TypeSpecjalRowsToSelect(xTxtIdElementSelect, xTxtActualStatus) {

    let cDropDownObject = new CDropDownOperations(xTxtIdElementSelect); //class

    //example: xTxtActualStatus = 'IN PROGRESS' or "CANCELED' itp.
    cDropDownObject.changeStatus(xTxtActualStatus);
}

//---4----------------------
function jDropDown_TypePossibleStatusesFromActualSelect(xTxtIdElementSelect) {

    let cDropDownObject = new CDropDownOperations(xTxtIdElementSelect); //class
		//alert("Start2");

    let aTxtActualChoice = cDropDownObject.possibleStatusesFromActualPopUp();
		alert("Actual choice in the ("+ xTxtIdElementSelect+ ") element was: ("+ aTxtActualChoice+")");
}


///=========================================

class CDropDownOperations {

		constructor(xTxtIdElementSelect) {

				this.pIdElementSelect = xTxtIdElementSelect;
        //example html: <select id="iselect-box"> //xTxtIdElementSelect = 'iselect-box';
    }

		addNewRowsToSelect(xTabTxt){
        this.removeSelectRowsAll();
        this.addRowsToSelect(xTabTxt); 
    }

		addRowsToSelect(xTabTxt){
        let parent = document.getElementById(this.pIdElementSelect); //("iselect-box");
        if(parent){
            const aCountLines = xTabTxt.length;
            for(let j=0; j<aCountLines; j++){
                let aTxtLine = xTabTxt[j]; //string
                this.addRowToSelect(aTxtLine);        
            }
        }
    }

    addRowToSelect(xTxtNewRow){
        const parent = document.getElementById(this.pIdElementSelect);
        if(parent){
            let aOption = document.createElement('option');
            //div.textContent = "Added Element";
            aOption.textContent = xTxtNewRow;
            parent.appendChild(aOption);
        }
    }

    removeSelectRow(){ //rtrtr
        const parent = document.getElementById(this.pIdElementSelect); //("iselect-box");
        if(parent){
            let CountRows = parent.length;
            parent[CountRows-1].remove();
        }
    }

    removeSelectRowsAll(){
        const parent = document.getElementById(this.pIdElementSelect); //("iselect-box");
        if(parent){
            let CountRows = parent.length;

            for(let j=0; j<CountRows; j++){
               parent[0].remove();
            }
        }
    }

    readActualPopUp(){
        const parent = document.getElementById(this.pIdElementSelect); // ("iselect-box");
        if(parent){

          //alert("Start2");

          let aTxtValue  = document.getElementById(this.pIdElementSelect).value;
          //let aTxtTxt  = document.getElementById('iselect-box').textContent; //Shows all position

          const parent = document.getElementById(this.pIdElementSelect);
          let aTxtTxt  = parent[parent.selectedIndex].textContent; //Shows all position
          //let aTxt = parent.selectmenu();

          //alert("ActualValue: " + aTxtValue + "\r"+ "ActualTxt: " + aTxtTxt	);
          return(aTxtTxt);
        }
    }

    changeStatus(xTxtActualStatus) {
        this.removeSelectRowsAll();
        //addRowsToSelect(xTabTxt); 

        let cStatus = new CStatus_HardwareDirect(xTxtActualStatus); //class 2
        const aTabTxtPossibleFutureStatuses = cStatus.mTabTxtPossibleFutureStatuses();

        // ['five','four','three','two','one']
        this.addNewRowsToSelect(aTabTxtPossibleFutureStatuses);
    }

    possibleStatusesFromActualPopUp(){
        const aTxtActualStatus = this.readActualPopUp();
        this.changeStatus(aTxtActualStatus);
        return(aTxtActualStatus);
    }


}

//============= CLASS 2 ================================

class CStatus_HardwareDirect {
 		constructor(xTxtActualStatus) {

				this.pTxtActualStatus = xTxtActualStatus;
    }

    mTabTxtPossibleFutureStatuses() { //method 
     		let aTabTxtStatuses = [];
				const aTxtActualStatus = this.pTxtActualStatus;


				switch(aTxtActualStatus) {
          case 'NEW':
          	aTabTxtStatuses = ["IN PROGRESS","CANCELED"];
            break;
          case 'IN PROGRESS':
          	aTabTxtStatuses = ["TO SPECIFY","TO TEST"];
            break;
          case 'TO SPECIFY':
          	aTabTxtStatuses = ["REOPENED","COMPLETED"];
            break;
          case 'REOPENED':
          	aTabTxtStatuses = ["IN PROGRESS","CANCELED"];
            break;
          case 'TO TEST':
          	aTabTxtStatuses = ["REOPENED","COMPLETED"];
            break;
          case 'COMPLETED':
          	aTabTxtStatuses = ["REOPENED","CANCELED"];
            break;
          case 'CANCELED':
          	aTabTxtStatuses = ["REOPENED"];
            break;
          default:
          	aTabTxtStatuses = ["NONE"];
        } //end switch         
        
        return(aTabTxtStatuses);
     }
} 	 //end class CStatus

function jDropDown_Alert(xTxtAlert) {

    alert("Alert: (" + xTxtAlert + ")");
}


