
// calendario para los controles
function datepicker(a) {
    var b = $("input[id$=" + a + "]").val();
    b
        ? ((b = b.split("/")), (today = new Date(b[2], b[1] - 1, b[0])))
        : ((date = new Date()),
            (today = new Date(date.getFullYear(), date.getMonth(), date.getDate())));
    $("input[id$=" + a + "]").datepicker({
        language: "es",
        dateFormat: 'dd/mm/yy',
        todayHighlight: !0,
        defaultDate: today,
        autoclose: !0,
        closeText: 'Cerrar',
        prevText: '< Ant',
        nextText: 'Sig >',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    });
    $("input[id$=" + a + "]").datepicker("setDate", today);
}

// Codigo para aceptar solo numeros con decimal en el control (se coloca allownumericwithdecimal en el atributo de CssStyle)
$(".allownumericwithdecimal").on("keypress keyup blur", function (event) {
    $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});

// Codigo para aceptar solo numeros sin decimal en el control (se coloca allownumericwithoutdecimal en el atributo de CssStyle)
$(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
    $(this).val($(this).val().replace(/[^\d].+/, ""));
    if ((event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});