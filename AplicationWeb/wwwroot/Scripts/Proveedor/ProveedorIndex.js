document.addEventListener("DOMContentLoaded", () => {

    const CargarProveedores = async (proveedores) => {
        try {

            //const response = await fetch('/Index/GetProductos'); // Ajusta la ruta según tu configuración

            //if (!response.ok) throw new Error('Error al obtener productos');

            //const productos = await response.json();
            const tbody = document.getElementById("proveedores-body");

            // Limpia el contenido existente
            tbody.innerHTML = "";
            //console.log(productos);

            // Agrega los nuevos proveedores
            proveedores.slice(0, 10).forEach(proveedor => {
                const row = `
                    <tr class="border-b dark:border-gray-700">
                    <th scope="row" class="px-4 py-3 font-medium text-gray-900 whitespace-nowrap dark:text-white"> ${proveedor.nombreEmpresa} </th>
                    <td class="px-4 py-3">${proveedor.diasVisita}</td>
                    <td class="px-4 py-3">${proveedor.tipoProducto}</td>
                    <td class="px-4 py-3">${proveedor.estado ? "Activo" : "Inactivo"}</td>
                    <td class="px-4 py-3">${proveedor.telefono}</td>
                    <td class="px-4 py-3">${proveedor.datosAdicionales}</td>
                    <td class="px-4 py-3">
                        <button type="button" id="btnEditar" data-id="${proveedor.idProveedor}" class=" btnEditar text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-2 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Editar</button>
                        <button type="button" id="btnEliminar" data-id="${proveedor.idProveedor}" class=" btnEliminar text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm px-2 py-1 text-center dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">Eliminar</button>
                    </tr>
        `;

                tbody.innerHTML += row;
            });
            tbody.addEventListener('click', (event) => {
                if (event.target.classList.contains('btnEditar')) {
                    const proveedorId = event.target.getAttribute('data-id');
                    RedirigirProveedor(proveedorId);
                    console.log(`Editar proveeedor con ID: ${proveedorId}`);


                    // Aquí puedes llamar a una función para abrir un modal o navegar a otra página
                } else if (event.target.classList.contains('btnEliminar')) {
                    const proveedorId = event.target.getAttribute('data-id');
                    RedirigirProveedor(proveedorId);
                    console.log(`Eliminar proveeedor con ID: ${proveedorId}`);
                    // Aquí puedes agregar la lógica para eliminar el producto
                }
            });
        } catch (error) {
            console.error("Error al cargar proveedores:", error);
        }
    };

    const CargarTodosLosProveedores = async () => {

        try {
            const response = await fetch('/Proveedor/GetProveedores'); // Ajusta la ruta según tu configuración
            console.log(response);
            if (!response.ok) throw new Error('Error al obtener proveedores');
            const proveedores = await response.json();
            CargarProveedores(proveedores);
        }
        catch (error) {
            console.error("Error al cargar proveedores:", error);
        }
    }
    const searchInput = document.getElementById('simple-search');

    // Función para mostrar proveedores en la tabla
    async function renderProveedores(palabra) {
        try {
            const response = await fetch('/Proveedor/GetProveedores'); // Ajusta la ruta según tu configuración
            const proveedores = await response.json();
            if (palabra.length > 0) {
                const proveedoresFiltrados = proveedores.filter((proveedor) => proveedor.nombreEmpresa.toLowerCase().startsWith(palabra));
                CargarProveedores(proveedoresFiltrados);
            }
            else CargarProveedores(proveedores);
        } catch (error) {
            console.log("error");
        }

    }

    // Escuchar evento de entrada en el campo de búsqueda
    searchInput.addEventListener('input', async () => {
        const searchTerm = searchInput.value.toLowerCase();
        if (searchTerm.length > 0) {
            renderProveedores(searchTerm);
        } else {
            renderProveedores(0);
        }
    });

    async function RedirigirProveedor(proveedorId) {
        if (!proveedorId) {
            console.error("No se encontró un ID de producto.");
            return;
        }
        console.log("ID del proveedor seleccionado:", proveedorId);

        try {
            window.location.href = `/Proveedor/EditarProveedor/${proveedorId}`

        } catch (error) {
            console.error("Error en la peticion:", error);
        }
    }


    CargarTodosLosProveedores();


});