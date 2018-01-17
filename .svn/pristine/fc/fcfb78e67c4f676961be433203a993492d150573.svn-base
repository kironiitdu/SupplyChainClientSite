function ValidateObject(data, validateFor, displayName) {
    var isValid = false;
    var position = 0;
    if (validateFor.length == 0) return true;
    $.each(data, function (key, value) {
        if (validateFor.indexOf(key) > -1) {
            if (!isValid) {
                if (value == "" || value == ' ' || value == null) {
                    swal("Alert !!!", displayName[position] + " should not be empty !!!", "warning");
                    isValid = true;
                }
                position++;
            }
            
        }
    });
    return isValid;
}

