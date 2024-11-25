const API_URL = "https://localhost:44317/api/";

const TIPOS_HARDCODED = [
    { id: "4A3E9F04-C7A7-4B4E-98A5-2F7277599BCC", nombre: "Pequeña" },
    { id: "CC8C9384-1290-4D66-B379-A5D0B24FCAA4", nombre: "Grande" }
];

const PROVINCIAS_HARDCODED = [
    { id: "3B04A1AD-FAFD-4142-837E-5F02816C3649", nombre: "Córdoba" },
    { id: "A76B2A6C-3EF4-49DC-B8E5-690DDA627417", nombre: "Buenos Aires" },
    { id: "E34A14E4-7C89-4609-A06B-86954E690ACA", nombre: "Santa Fe" }
];


function cargarProvincias() {
    /* Versión con endpoint 
    $.ajax({
        url: `${API_URL}provincias`,
        method: 'GET',
        success: function(response) {
            if (!response.success) {
                alert(response.message);
                return;
            }
            const provincias = response.data;
    */
    
    // Versión hardcodedeada
    const provincias = PROVINCIAS_HARDCODED;
    const select = $('#provinciaSelect');
    select.empty();
    select.append(new Option('Seleccione una provincia', ''));
    
    provincias.forEach(provincia => {
        select.append(new Option(provincia.nombre, provincia.id));
    });
}

function cargarTipos() {
    /* Versión con endpoint 
    $.ajax({
        url: `${API_URL}tipos`,
        method: 'GET',
        success: function(response) {
            if (!response.success) {
                alert(response.message);
                return;
            }
            const tipos = response.data;
    */
    
    // Versión hardcodedeada
    const tipos = TIPOS_HARDCODED;
    const select = $('#tipoSelect');
    select.empty();
    select.append(new Option('Seleccione un tipo', ''));
    
    tipos.forEach(tipo => {
        select.append(new Option(tipo.nombre, tipo.id));
    });
}

$(document).ready(function() {
   // Cargar datos iniciales
   cargarProvincias();
   cargarTipos();

   // Configurar validación
   $('#formCrear').validate({
       rules: {
           nombreInput: {
               required: true,
               minlength: 3
           },
           ciudadInput: {
               required: true
           },
           provinciaSelect: {
               required: true
           },
           tipoSelect: {
               required: true
           },
           telefonoInput: {
               required: true,
               minlength: 8
           },
           nombreTitularInput: {
               required: true
           },
           apellidoTitularInput: {
               required: true
           }
       },
       messages: {
           nombreInput: {
               required: "Por favor ingrese un nombre",
               minlength: "El nombre debe tener al menos 3 caracteres"
           },
           ciudadInput: {
               required: "Por favor ingrese una ciudad"
           },
           provinciaSelect: {
               required: "Por favor seleccione una provincia"
           },
           tipoSelect: {
               required: "Por favor seleccione un tipo"
           },
           telefonoInput: {
               required: "Por favor ingrese un teléfono",
               minlength: "El teléfono debe tener al menos 8 números"
           },
           nombreTitularInput: {
               required: "Por favor ingrese el nombre del titular"
           },
           apellidoTitularInput: {
               required: "Por favor ingrese el apellido del titular"
           }
       },
       errorElement: 'span',
       errorClass: 'text-danger',
       highlight: function(element) {
           $(element).closest('.form-group').addClass('has-error');
       },
       unhighlight: function(element) {
           $(element).closest('.form-group').removeClass('has-error');
       },
       submitHandler: function(form) {
           const sucursalData = {
               nombre: $('#nombreInput').val(),
               ciudad: $('#ciudadInput').val(),
               idProvincia: $('#provinciaSelect').val(),
               idTipo: $('#tipoSelect').val(),
               telefono: $('#telefonoInput').val(),
               nombreTitular: $('#nombreTitularInput').val(),
               apellidoTitular: $('#apellidoTitularInput').val(),
               fechaAlta: new Date().toISOString()
           };

           $.ajax({
               url: `${API_URL}sucursales`,
               method: 'POST',
               contentType: 'application/json',
               data: JSON.stringify(sucursalData),
               success: function(response) {
                   if (!response.success) {
                       alert(response.message);
                       return;
                   }
                   alert('Sucursal creada exitosamente');
                   window.location.href = 'sucursales.html';
               },
               error: function(xhr, status, error) {
                   console.error("Error:", error);
                   alert("Error al crear la sucursal");
               }
           });
       }
   });
});