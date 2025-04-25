document.addEventListener("DOMContentLoaded", () => {
    //Funcion para cargar los productos
    const botonCargar = document.getElementById("cargar-productos-btn");

  
    const CargarProductos = async (productos) => {
        try {

            //const response = await fetch('/Index/GetProductos'); // Ajusta la ruta según tu configuración

            //if (!response.ok) throw new Error('Error al obtener productos');

            //const productos = await response.json();
            const tbody = document.getElementById("productos-body");

            // Limpia el contenido existente
            tbody.innerHTML = "";
            //console.log(productos);

            // Agrega los nuevos productos
            productos.slice(0, 10).forEach(producto => {
                const row = `
                    <tr class="border-b dark:border-gray-700">
                    <th scope="row" class="px-4 py-3 font-medium text-gray-900 whitespace-nowrap dark:text-white"> ${producto.nombre} </th>
                    <td class="px-4 py-3">${producto.stockDisponible.cantidadActual}</td>
                    <td class="px-4 py-3">${producto.categoria.nombre}</td>
                    <td class="px-4 py-3 max-w-[12rem] truncate">${producto.nombreProveedor}</td>
                    <td class="px-4 py-3">${producto.historialProductos.precioPublico}</td>
                    <td class="px-4 py-3">
                        <button type="button" id="btnEditar" data-id="${producto.idProducto}" class=" btnEditar text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-2 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Editar</button>
                        <button type="button" id="btnEliminar" data-id="${producto.idProducto}" class=" btnEliminar text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm px-2 py-1 text-center dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">Eliminar</button>
                    </tr>
                    

        `;
               
                tbody.innerHTML += row;
            });
            tbody.addEventListener('click', (event) => {
                if (event.target.classList.contains('btnEditar')) {
                    const productoId = event.target.getAttribute('data-id');
                    RedirigirProducto(productoId);
                    console.log(`Editar producto con ID: ${productoId}`);


                    // Aquí puedes llamar a una función para abrir un modal o navegar a otra página
                } else if (event.target.classList.contains('btnEliminar')) {
                    const productoId = event.target.getAttribute('data-id');
                    console.log(`Eliminar producto con ID: ${productoId}`);
                    // Aquí puedes agregar la lógica para eliminar el producto
                }
            });
        } catch (error) {
            console.error("Error al cargar productos:", error);
        }
    };
    //const CargarProductos = async (page = 1, pageSize = 10) => {
    //    try {
    //        const response = await fetch(`/api/productos?page=${page}&pageSize=${pageSize}`, {
    //            headers: {
    //                "Accept": "application/json"
    //            }
    //        });
    //        if (!response.ok) throw new Error("Error al obtener productos");

    //        const data = await response.json();


    //        const productos = data.items.items; // Accede al array dentro de `items`
    //        const totalCount = data.items.totalCount; // Accede al totalCount correcto
    //        //const data = await response.json();
    //        //const productos = data.items; // Asegúrate de obtener el array de productos

    //        const tbody = document.getElementById("productos-body");

    //        // Limpia el contenido existente
    //        tbody.innerHTML = "";

    //        // Agrega los nuevos productos
    //        productos.forEach(producto => {
    //            const row = `
    //            <tr class="border-b dark:border-gray-700">
    //                <th scope="row" class="px-4 py-3 font-medium text-gray-900 whitespace-nowrap dark:text-white"> ${producto.nombre} </th>
    //                <td class="px-4 py-3">${producto.stockDisponible.cantidadActual}</td>
    //                <td class="px-4 py-3">${producto.categoriaId}</td>
    //                <td class="px-4 py-3 max-w-[12rem] truncate">${producto.nombreProveedor}</td>
    //                <td class="px-4 py-3">$1000</td>
    //            </tr>
    //        `;
    //            tbody.innerHTML += row;
    //        });

    //        // Actualiza la navegación de páginas
    //        ActualizarPaginacion(totalCount, page);
    //    } catch (error) {
    //        console.error("Error al cargar productos:", error);
    //    }
    //};

    const searchInput = document.getElementById('simple-search');

    // Función para mostrar productos en la tabla
    async function renderProductos(palabra) {
        try {
            const response = await fetch('/Index/GetProductos'); // Ajusta la ruta según tu configuración
            const productos = await response.json();
            if (palabra.length > 0) {
                const productosFiltrados = productos.filter((producto) => producto.nombre.toLowerCase().startsWith(palabra));
                CargarProductos(productosFiltrados);
            }
            else CargarProductos(productos);
        } catch (error)
        {
            console.log("error");
        }
        
    }

    // Escuchar evento de entrada en el campo de búsqueda
    searchInput.addEventListener('input', async () => {
        const searchTerm = searchInput.value.toLowerCase();
        if (searchTerm.length > 0) {
            renderProductos(searchTerm);
        } else {
            renderProductos(0);
        }
    });

    const CargarTodosLosProductos = async () => {

        try {
            const response = await fetch('/Index/GetProductos'); // Ajusta la ruta según tu configuración

            if (!response.ok) throw new Error('Error al obtener productos');
            const productos = await response.json();
            CargarProductos(productos);
        }
        catch (error) {
            console.error("Error al cargar productos:", error);
        }
    }

    async function RedirigirProducto(productoId) {
        if (!productoId) {
            console.error("No se encontró un ID de producto.");
            return;
        }
        console.log("ID del producto seleccionado:", productoId);

        try {
            window.location.href = `/Producto/EditarProducto/${productoId}`;
            

            // Llamar al endpoint con el ID del producto
            //const response = await fetch(`/Producto/ObtenerProducto/${productoId}`, {
            //    method: "GET",
            //    headers: {
            //        "Content-Type": "application/json",
            //    },
            //});

            //if (!response.ok) {
            //    throw new Error("Error al obtener el producto.");
            //}

            //const producto = await response.json();
            //console.log("Datos del producto recibido:", producto);

            // Guardar el producto en localStorage
            //localStorage.setItem("productoEditar", JSON.stringify(producto));

            // Redirigir a la página de edición con los datos en la URL
            //const redirigir = await fetch(`/Producto/EditarProducto/${productoId}`, {
            //    method: "GET",
            //    headers: {
            //        "Content-Type": "application/json",
            //    },
            //});
            //if (!redirigir.ok) {
            //    throw new Error("Error al obtener el producto.");
            //}
            //else {
            //    const r = await redirigir.json();
            //    console.log(r);
            //}
            //window.location.href = `/Producto/EditarProducto/${producto.idProducto}`;

        } catch (error) {
            console.error("Error en la peticion:", error);
        }
    };


    CargarTodosLosProductos();





    //const ProductosBuscados = async () => {
    //    const searchTerm = document.getElementById('searchInput').value;
    //    const response = await fetch(`/api/search?filter=${encodeURIComponent(searchTerm)}`);
    //    const data = await response.json();
    //    Resultados(data);
    //};

    //const Resultados = (results) => {
    //    const resultsContainer = document.getElementById('results');
    //    resultsContainer.innerHTML = results.map(item => `
    //    <div class="p-4 border rounded-md">
    //        <h2 class="text-xl">${item.name}</h2>
    //        <p>${item.description}</p>
    //    </div>
    //`).join('');
    //};


   
});










    // Variables para la paginación
    //let currentPage = 1; // Página actual
    //const itemsPerPage = 10; // Número de productos por página

    //// Función para mostrar productos
    //function displayProducts(productos, currentPage, itemsPerPage) {
    //    const startIndex = (currentPage - 1) * itemsPerPage;
    //    const endIndex = startIndex + itemsPerPage;

    //    // Obtener los productos para la página actual
    //    const productsToDisplay = productos.slice(startIndex, endIndex);

    //    // Limpiar contenido previo
    //    tbody.innerHTML = "";

    //    // Mostrar productos en la tabla
    //    productsToDisplay.forEach(producto => {
    //        const row = `
    //        <tr class="border-b dark:border-gray-700">
    //        <th scope="row" class="px-4 py-3 font-medium text-gray-900 whitespace-nowrap dark:text-white">${producto.nombre}</th>
    //        <td class="px-4 py-3">${producto.stockDisponible.cantidadActual}</td>
    //        <td class="px-4 py-3">${producto.categoriaId}</td>
    //        <td class="px-4 py-3 max-w-[12rem] truncate">${producto.nombreProveedor}</td>
    //        <td class="px-4 py-3">$1000</td>
    //        </tr>
    //    `;
    //        tbody.innerHTML += row;
    //    });

    //    // Actualizar rango de visualización
    //    const start = startIndex + 1;
    //    const end = Math.min(endIndex, productos.length);
    //    document.querySelector(".text-sm span.font-semibold:nth-child(1)").innerText = `${start}-${end}`;
    //    document.querySelector(".text-sm span.font-semibold:nth-child(3)").innerText = `${productos.length}`;
    //}

    //// Función para cambiar de página
    //function cambiarPagina(direction) {
    //    const totalPages = Math.ceil(productos.length / itemsPerPage);

    //    if (direction === "next" && currentPage < totalPages) {
    //        currentPage++;
    //    } else if (direction === "prev" && currentPage > 1) {
    //        currentPage--;
    //    }

    //    displayProducts(productos, currentPage, itemsPerPage);
    //}

    //// Listeners para los botones de navegación
    //document.querySelector(".prev-button").addEventListener("click", () => cambiarPagina("prev"));
    //document.querySelector(".next-button").addEventListener("click", () => cambiarPagina("next"));

    ////Llama la funcion al cargar la pagina
    

    //// Vincula el evento del botón para cargar productos manualmente
    //if (botonCargar) {
    //    botonCargar.addEventListener("click", CargarProductos);
    //}
    


