document.addEventListener("DOMContentLoaded", function () {

    document.getElementById("formulario").addEventListener("submit", function (event) {
        event.preventDefault(); // Evita la recarga de la página

        const form = this;
        const formData = new FormData(this);
        const mensajeDiv = document.getElementById("mensajeVerificacion");
        console.log(formData);

        fetch('/Producto/ActualizarProducto', {
            method: "POST",
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                mensajeDiv.textContent = data.message;
                mensajeDiv.classList.remove("hidden");
                mensajeDiv.classList.add(data.success ? "bg-green-500" : "bg-red-500", "animate-fade-in");

                if (data.success) {
                    form.reset();
                    setTimeout(() => location.reload(), 2000); // Recargar después de éxito
                } else {
                    setTimeout(() => mensajeDiv.classList.add("hidden"), 3000); // Ocultar en caso de error
                }
            })
            .catch(error => console.error("Error:", error));
    });
    // Función para calcular el precio al público
    function calcularPrecioPublico() {
        const precioProducto = parseFloat(document.getElementById("precioProducto").value) || 0;
        const porcentajeGanancia = parseFloat(document.getElementById("porcentajeGanancia").value) || 0;

        // Calcular el precio al público
        const precioPublico = precioProducto * (1 + porcentajeGanancia / 100);

        // Mostrar el resultado en el campo de precio público
        document.getElementById("precioPublico").value = precioPublico.toFixed(2); // Redondea a 2 decimales
    }


    document.getElementById("precioProducto").addEventListener("input", calcularPrecioPublico);
    document.getElementById("porcentajeGanancia").addEventListener("input", calcularPrecioPublico);
    
});
