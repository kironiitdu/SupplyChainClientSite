/* start custom kendo window function */
function KendoWindowFunction(msg, status,action) {

    var window = jQuery("#kWindow");
    if (!window.data("kendoWindow")) {
        window.kendoWindow({
            title: "Message Window",
            modal: true,
            height: 100,
            width: 400
        });
    }
    window.data("kendoWindow").center().open();

    var okHtml = '';
    if (status === "error") {
        okHtml = '<div id="message_div"><br/><p style="color:red;font-weight:bold;text-align:center;">' + msg + '</p>';
        okHtml += '<div class="clearfix"></div>';
        okHtml += '<a href="javascript:void(0);" id="btnCancel" class="k-button pull-right">OK</a>';
        okHtml += '<script type="text/javascript">';
        okHtml += ' $(document).ready(function(){';
        okHtml += '  $("#btnCancel").click(function(){';
        okHtml += '    $(".k-i-close").click();';
        okHtml += '  });';
        okHtml += '    });';
        okHtml += '</scr' + 'ipt>';
        okHtml += '</div>';
    } else {
        okHtml = '<div id="message_div"><br/><p id="msg_display" style="color:green;font-weight:bold;text-align:center;">' + msg + '</p>';
        okHtml += '<div class="clearfix"></div>';
        okHtml += '<a href="javascript:void(0);" id="btnReload" class="k-button pull-right">OK</a>';
        okHtml += '<script type="text/javascript">';
        okHtml += ' $(document).ready(function(){';
        okHtml += '  $("#btnReload").click(function(){';
        okHtml += '    location.replace("'+action+'");';
        okHtml += '  });';
        okHtml += '    });';
        okHtml += '</scr' + 'ipt>';
        okHtml += '</div>';
    }
    window.html(okHtml);
    return false;
    //this.cancelChanges();
}
/* end custom kendo window function */
