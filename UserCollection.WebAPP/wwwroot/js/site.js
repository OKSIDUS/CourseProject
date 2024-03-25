function showNextField() {
    var fieldType = $('#newFieldType').val();
    var $fields = $('#custom' + fieldType + 'Fields').children('.form-group:hidden');
    console.log(fieldType);
    if ($fields.length > 0) {
        console.log("here");
        $fields.first().show();
    }
}