/*okno.js* Copyright (c) 2010 ZTC HADRON. All Rights Reserved. */;

function Subokno(URL,dx,dy){
 iw=window.open('','iw',"toolbar=no,location=no,directories=no,status=no,scrollbars=1,resizable=1,width=200,height=200");
 iw.document.open();
 iw.document.write('<html><head><title>Powiekszenie</title></head>');
 iw.document.write('<BODY BGCOLOR="#004080" LEFTMARGIN="0" MARGINWIDTH="0" TOPMARGIN="0" MARGINHEIGHT="0">');
 iw.document.write('<A href="" onClick="window.close()"><img src="' + URL + '" border="0" alt="Zamyka okno"></a>');
 iw.document.write('</body></html>');
 iw.document.close();
 iw.resizeTo(dx+30,dy+34);
 iw.focus();
}

function submitForm() {
    var xmlhttp = new XMLHttpRequest();

    var fn = document.getElementById('jtext1').value;
    //var ln = document.getElementById('lname').value;
    //var e = document.getElementById('email').value;
    //var p = document.getElementById('phone').value;
    //var m = document.getElementById('message').value;

    alert(fn);

    var test = document.getElementById('sel2').value;

    alert(test);
}


