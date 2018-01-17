function NotificationMessage(data) {
    if (data.output === "Success" || data.output === "success") {
        swal("Success", data.msg, "success"); return;
    }
    else if (data.output === "Exception" || data.output === "Error" || data.output === "error") {
        swal("Exception", data.msg, "error"); return;
    }
    //else if (data.messageType == 3) {
    //    alertify.alert("------------------------------- Warning -------------------------------", data.message);

    //    return;
    //}
    //else if (data.messageType == 4) {
    //    alertify.alert("------------------------------- Exception -------------------------------", data.message); return;
    //}
    //else if (data.messageType == 5) {
    //    alertify.alert("------------------------------- Duplicate -------------------------------", data.message); return;
    //}
}

function NotificationMessageWithCustomeUrl(data, url) {
    if (data.output === "Success" || data.output === "success") {
        swal("Success", data.msg, "success");
        $('.confirm').click(function () {
            location.replace(url);
        });

    }
    return false;
}



function NotificationMessageWithRefresh(data) {
    if (data.output === "Success" || data.output === "success") {
        swal("Success", data.msg, "success");
        $('.confirm').click(function () {
            var loc = location.href;
            var checkquerystring = loc.split('?')[0];
            if (checkquerystring != null) {
                location.replace(checkquerystring);
            } else {
                location.replace(loc);
            }
        });

    }
    return false;
}


function regExpname(str, elementId) {
    var regex = /^([a-zA-Z\s,-])+$/;
    if (!(regex.test(str))) {
        $.gritter.add({
            text: 'Please insert valid information.',
            sticky: false,
            time: '1000'
        });
        $('#' + elementId).addClass('required');
        $('#' + elementId).focus();
        regExpvalidation = false;
        return false;
    }
    $('input').removeClass('required');
    regExpvalidation = true;
    return true;
}
function regExpweb(str, elementId) {
    var regex = /(((http|ftp|https):\/\/)?([\w-]+(\.[\w-]+)+([\w.,@?^=%&amp;:\/~+#-]*[\w@?^=%&amp;\/~+#-])))/;
    if (!(regex.test(str))) {
        alertify.error("Please insert valid Web URL.", 2);
        $('#' + elementId).addClass('required');
        $('#' + elementId).focus();
        regExpvalidation = false;
        return false;
    }
    $('input').removeClass('required');
    regExpvalidation = true;
    return true;
}
function regExpmobile(str, elementId) {
    var regex = /^(\+88-|\+88|0|\88)?\d{11}$/;
    if (!(regex.test(str))) {
        alertify.error("Please insert valid information.", 2);
        $('#' + elementId).addClass('required');
        $('#' + elementId).focus();
        regExpvalidation = false;
        return false;
    }
    $('input').removeClass('required');
    regExpvalidation = true;
    return true;
}
function regExpemail(str, elementId) {
    var regex = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    if (!(regex.test(str))) {
        alertify.error("Please insert valid email address.", 2);
        $('#' + elementId).addClass('required');
        $('#' + elementId).focus();
        regExpvalidation = false;
        return false;
    }
    $('input').removeClass('required');
    regExpvalidation = true;
    return true;
}
function regExpaccno(str, elementId) {
    var regex = /^(?:[0-9]{11,16})$/;
    if (!(regex.test(str))) {
        alertify.error("Please insert valid information.", 2);
        $('#' + elementId).addClass('required');
        $('#' + elementId).focus();
        regExpvalidation = false;
        return false;
    }
    $('input').removeClass('required');
    regExpvalidation = true;
    return true;
}
function regExpBillNo(str) {
    var regex = /^(?:[0-9]{6,11})$/;
    return regex.test(str);
}
function regExpbalance(str, elementId) {
    var regex = /^[0-9]*$/;
    if (!(regex.test(str))) {
        alertify.error("Please insert valid information.", 2);
        $('#' + elementId).addClass('required');
        $('#' + elementId).focus();
        regExpvalidation = false;
        return false;
    }
    $('input').removeClass('required');
    regExpvalidation = true;
    return true;
}

function isValidName(str) {
    var regex = /^([a-zA-Z(\s)?,-.]{5,50})+$/;
    return regex.test(str);
}

function isValidMobile(str, elementId) {
    var regex = /^(\+88-|\+88|0|\88)?\d{11}$/;
    return regex.test(str);
}
function isValidPhone(str, elementId) {
    var regex = /^[\d,-]+?$/;
    return regex.test(str);
}

function isValidAccNo(str) {
    var regex = /^(?:[0-9]{11,16})$/;
    return regex.test(str);
}
function isValidMoney(str) {
    var regex = /^\d+(\.\d{1,2})?$/;
    return regex.test(str);
}
function isValidPassport(str) {
    var regex = /^([a-zA-Z\s]{2})\d{7}$/;
    return regex.test(str);
}
