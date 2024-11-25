
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


// Obtener ID de la sucursal
const sucursalId = localStorage.getItem('sucursalId');

// alternativa por parametros de URL
/*
function obtenerIdPorURL() {
   const urlParams = new URLSearchParams(window.location.search);
   return urlParams.get('id');
}
const sucursalId = obtenerIdPorURL();
*/

function cargarDatosSucursal() {
   // Cargar datos de la sucursal
   $.ajax({
       url: `${API_URL}sucursales/${sucursalId}`,
       method: 'GET',
       success: function(response) {
           if (!response.success) {
               alert(response.message);
               return;
           }

           const sucursal = response.data;

           // Cargar datos en el formulario
           $('#sucursalId').val(sucursal.id);
           $('#nombreInput').val(sucursal.nombre);
           $('#ciudadInput').val(sucursal.ciudad);
           $('#telefonoInput').val(sucursal.telefono);
           $('#nombreTitularInput').val(sucursal.nombreTitular);
           $('#apellidoTitularInput').val(sucursal.apellidoTitular);

           // Cargar provincias y tipos
           cargarProvincias(sucursal.idProvincia);
           cargarTipos(sucursal.idTipo);
       },
       error: function(xhr, status, error) {
           console.error("Error:", error);
           alert("Error al cargar los datos de la sucursal");
       }
   });
}

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

async function cargarTipos() {
    /* Versión con endpoint 
    try {
        const response = await fetch(`${API_URL}tipos`);
        const responseJson = await response.json();
        if (!responseJson.success) {
            alert(responseJson.message);
            return;
        }
        const tipos = responseJson.data;
    */
    
    // Versión hardcodedada
    const tipos = TIPOS_HARDCODED;
    const select = document.getElementById('tipoSelect');
    
    tipos.forEach(tipo => {
        const option = document.createElement('option');
        option.value = tipo.id;
        option.textContent = tipo.nombre;
        select.appendChild(option);
    });
}

// jquery validate
$(document).ready(function() {
   $('#formEditar').validate({
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
           }
       },
       submitHandler: function(form) {
           const sucursalData = {
               id: $('#sucursalId').val(),
               nombre: $('#nombreInput').val(),
               ciudad: $('#ciudadInput').val(),
               idProvincia: $('#provinciaSelect').val(),
               idTipo: $('#tipoSelect').val(),
               telefono: $('#telefonoInput').val(),
               nombreTitular: $('#nombreTitularInput').val(),
               apellidoTitular: $('#apellidoTitularInput').val()
           };

           $.ajax({
               url: `${API_URL}sucursales`,
               method: 'PUT',
               contentType: 'application/json',
               data: JSON.stringify(sucursalData),
               success: function(response) {
                   if (!response.success) {
                       alert(response.message);
                       return;
                   }
                   alert('Sucursal actualizada exitosamente');
                   window.location.href = 'sucursales.html';
               },
               error: function(xhr, status, error) {
                   console.error("Error:", error);
                   alert("Error al actualizar la sucursal");
               }
           });
       }
   });

   // Cargar datos iniciales
   cargarDatosSucursal();
});