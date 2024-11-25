const API_URL = "https://localhost:44317/api/";

async function cargarSucursales() {
    try {
        const response = await fetch(`${API_URL}sucursales`);
        let responseJson = await response.json();
        
        if (!responseJson.success) {
            alert(responseJson.message);
            return;
        }

        let sucursales = responseJson.data;
        let sucursalesBody = document.getElementById("sucursalesBody");
        sucursalesBody.innerHTML = ''; // Limpiar contenido existente

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
            sucursalesBody.innerHTML += row;
        });
    } catch (error) {
        console.error("Error:", error);
        alert("Error al cargar las sucursales");
    }
}

function editarSucursal(idSucursal) {
    // Guardar en localStorage
    localStorage.setItem('sucursalId', idSucursal);
    // Redireccionar con parámetro en URL
    window.location.href = `editar-sucursal.html?id=${idSucursal}`;
}

// Cargar sucursales al iniciar la página
document.addEventListener('DOMContentLoaded', cargarSucursales);