const API_URL = "https://localhost:44317/api/";

function cargarSucursales() {
    $.ajax({
        url: `${API_URL}sucursales`,
        method: 'GET',
        success: function(response) {
            if (!response.success) {
                alert(response.message);
                return;
            }

            const sucursales = response.data;
            const sucursalesBody = $("#sucursalesBody");
            sucursalesBody.empty();

            sucursales.forEach(sucursal => {
                const row = `
                    <tr>
                        <td>${sucursal.nombre}</td>
                        <td>${sucursal.ciudad}</td>
                        <td>${sucursal.provinciaNombre}</td>
                        <td>${sucursal.tipoNombre}</td>
                        <td>${sucursal.telefono}</td>
                        <td>${sucursal.nombreTitular} ${sucursal.apellidoTitular}</td>
                        <td>
                            <button class="btn btn-primary" 
                                    onclick="editarSucursal('${sucursal.id}')">
                                Editar
                            </button>
                        </td>
                    </tr>`;
                sucursalesBody.append(row);
            });
        },
        error: function(xhr, status, error) {
            console.error("Error:", error);
            alert("Error al cargar las sucursales");
        }
    });
}

function editarSucursal(idSucursal) {
    // Guardar en localStorage
    localStorage.setItem('sucursalId', idSucursal);
    // Redireccionar con parámetro en URL
    window.location.href = `editar-sucursal.html?id=${idSucursal}`;
}

// Cargar sucursales al iniciar la página
$(document).ready(function() {
    cargarSucursales();
});