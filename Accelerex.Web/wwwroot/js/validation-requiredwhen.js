jQuery.validator.addMethod("requiredwhen", function (value, element, param) {        
    var otherPropId = $(element).data('val-other');
    var otherPropVal = $(element).data('val-otherval');
    if (otherPropId) {
        var otherProp = $(otherPropId);
        if (otherProp) {
            var otherVal = otherProp.val();

            if ($(otherProp).is('input[type="radio"], input[type="checkbox"]')) {
                otherVal = $(otherPropId + ':checked').val();
            }

            if ($(otherProp).is('select')) {
                otherVal = $(otherPropId + ':selected').val();
            }

            if (otherVal === otherPropVal) {
                return element.value.length > 0;
            }
        }
    }
    return true;
});
jQuery.validator.unobtrusive.adapters.addBool("requiredwhen");

//jQuery.validator.addMethod("requiredwhen", function (value, element, param) {
//    var otherPropId = $(element).data('val-other');
//    if (otherPropId) {
//        var otherProp = $(otherPropId)[0].checked;
//        if (otherProp) {
//            return element.value.length > 0;
//        }
//    }
//    return true;
//});
//jQuery.validator.unobtrusive.adapters.addBool("requiredwhen");