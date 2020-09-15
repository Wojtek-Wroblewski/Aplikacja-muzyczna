function Edit(element) {

    console.log("edit");
    var parent = $(element).parent().parent();
    var placeholder = $(parent).find('.text-info').text();
    //hide label
    $(parent).find('label').hide();
    //show input, set placeholder
    var input = $(parent).find('input[type="text"]');
    var edit = $(parent).find('.controls-edit');
    var update = $(parent).find('.controls-update');
    $(input).show();
    $(edit).hide();
    $(update).show();
    //$(input).attr('placeholder', placeholder);
}

function Update(element) {

    console.log("update");
    var parent = $(element).parent().parent();
    var placeholder = $(parent).find('.text-info').text();
    //hide label
    $(parent).find('label').show();
    //show input, set placeholder
    var input = $(parent).find('input[type="text"]');
    var edit = $(parent).find('.controls-edit');
    var update = $(parent).find('.controls-update');
    $(input).hide();
    $(edit).show();
    $(update).hide();
    //$(input).attr('placeholder', placeholder);
    $(parent).find('label').text($(input).val());
}