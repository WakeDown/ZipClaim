function ActionConfirm(message) {
    return confirm('Вы действительно хотите ' + message + '?');
}

function DeleteConfirm(name) {
    return confirm('Вы действительно хотите удалить ' + name + '?');
}

function initControlDisableStateElementAndText(chkId, inputId, textOnDisalbe, isChecked, validatorId) {
    if ($('#' + inputId)[0].disabled == true) {
        isChecked = false;
    }

    $('#' + chkId).prop('checked', isChecked);
    $('#' + chkId).on('change', function() {
        //$('#' + inputId).prop('placeholder', textOnDisalbe);
        var checked = $(this).prop('checked');

        $('#' + inputId).prop('disabled', !checked);

        if (!checked) {
            $('#' + inputId).prop('placeholder', textOnDisalbe).val(null);
        } else {
            $('#' + inputId).prop('placeholder', '');//.focus();
        }
        var validator = $('#' + validatorId);
        try {
            ValidatorEnable(validator[0], checked);
        }catch (e){}

    }).change();
}

function showSpinner(obj, offset, offsetTop, offsetLeft) {
    var of = "";
    var stOf = "";
    if (offset) {
        of = "on-element";
        stOf = "top:" + offsetTop + "px;left:" + offsetLeft + "px";
    }
    var loading = "<div class='spinner active " + of + "' style='" + stOf + "'><i class='fa fa-spin fa-spinner'></i></div>";
    $(obj).before(loading);
}

function showSpinnerAfter(obj, offset, offsetTop, offsetLeft) {
    var of = "";
    var stOf = "";
    if (offset) {
        of = "on-element";
        if (offsetTop == undefined || offsetTop == null || offsetTop == '') offsetTop = 5;
        stOf = "top:" + offsetTop + "px;left:" + offsetLeft + "px";
    }
    var loading = "<div class='spinner active " + of + "' style='" + stOf + "'><i class='fa fa-spin fa-spinner'></i></div>";
    $(obj).after(loading);
}

function showSpinnerAppend(obj, offset, offsetTop, offsetLeft) {
    var of = "";
    var stOf = "";
    if (offset) {
        of = "on-element";
        stOf = "top:" + offsetTop + "px;left:" + offsetLeft + "px";
    }
    var loading = "<div class='spinner active " + of + "' style='" + stOf + "'><i class='fa fa-spin fa-spinner'></i></div>";
    $(obj).prepend(loading);
}

function showSpinnerPrepend(obj, offset, offsetTop, offsetLeft) {
    var of = "";
    var stOf = "";
    if (offset) {
        of = "on-element";
        stOf = "top:" + offsetTop + "px;left:" + offsetLeft + "px";
    }
    var loading = "<div class='spinner active " + of + "' style='" + stOf + "'><i class='fa fa-spin fa-spinner'></i></div>";
    $(obj).prepend(loading);
}

function hideSpinner(obj) {
    if (obj) {
        $(obj).parent().find(".spinner.active").remove();
    } else {
        $(".spinner").remove();
    };
}

function replaceQueryString(url, param, value) {
    if (url.lastIndexOf('?') <= 0) url = url + "?";

    var re = new RegExp("([?|&])" + param + "=.*?(&|$)", "i");
    if (url.match(re))
        return url.replace(re, '$1' + param + "=" + value + '$2');
    else
        return url.substring(url.length - 1) == '?'
            ? url + param + "=" + value
            : url + '&' + param + "=" + value;
}

String.prototype.replaceAll = function (target, replacement) {
    return this.split(target).join(replacement);
};