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



async function cargarProvincias() {
    /* Versión con endpoint 
    try {
        const response = await fetch(`${API_URL}provincias`);
        const responseJson = await response.json();
        if (!responseJson.success) {
            alert(responseJson.message);
            return;
        }
        const provincias = responseJson.data;
    */
    
    // Versión hardcodedeada
    const provincias = PROVINCIAS_HARDCODED;
    const select = document.getElementById('provinciaSelect');
    
    provincias.forEach(provincia => {
        const option = document.createElement('option');
        option.value = provincia.id;
        option.textContent = provincia.nombre;
        select.appendChild(option);
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
    
    // Versión hardcodedeada
    const tipos = TIPOS_HARDCODED;
    const select = document.getElementById('tipoSelect');
    
    tipos.forEach(tipo => {
        const option = document.createElement('option');
        option.value = tipo.id;
        option.textContent = tipo.nombre;
        select.appendChild(option);
    });
}

async function crearSucursal(event) {
    event.preventDefault();

    const sucursalData = {
        nombre: document.getElementById('nombreInput').value,
        ciudad: document.getElementById('ciudadInput').value,
        idProvincia: document.getElementById('provinciaSelect').value,
        idTipo: document.getElementById('tipoSelect').value,
        telefono: document.getElementById('telefonoInput').value,
        nombreTitular: document.getElementById('nombreTitularInput').value,
        apellidoTitular: document.getElementById('apellidoTitularInput').value,
        fechaAlta: new Date().toISOString() // Fecha actual
    };

    try {
        const response = await fetch(`${API_URL}sucursales`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(sucursalData)
        });

        const responseJson = await response.json();

        if (!responseJson.success) {
            alert(responseJson.message);
            return;
        }

        alert('Sucursal creada exitosamente');
        window.location.href = 'sucursales.html';
    } catch (error) {
        console.error("Error:", error);
        alert("Error al crear la sucursal");
    }
}

// Event Listeners
document.addEventListener('DOMContentLoaded', () => {
    cargarProvincias();
    cargarTipos();
    document.getElementById('formCrear').addEventListener('submit', crearSucursal);
});