document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("formulario").addEventListener("submit", function (event) {
        event.preventDefault(); // Evita la recarga de la página

        const form = this;
        const formData = new FormData(this);
        const mensajeDiv = document.getElementById("mensajeVerificacion");

        fetch("/Producto/CreacionProducto", {
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





















    //document.getElementById("formulario").addEventListener("submit", function () {

    //    const mensajeDiv = document.getElementById("mensajeVerificacion");
    //    const successMessage = "@(successMessage ?? )";
    //    const errorMessage = "@(errorMessage ?? )";

    //    let mensajeVerificacion = "";
    //    let bgColor = "";

    //    if (successMessage.trim()) {
    //        mensajeVerificacion = successMessage;
    //        bgColor = "bg-green-500";
    //    } else if (errorMessage.trim()) {
    //        mensajeVerificacion = errorMessage;
    //        bgColor = "bg-red-500";
    //    }

    //    if (mensajeVerificacion) {
    //        mensajeDiv.textContent = mensajeVerificacion;
    //        mensajeDiv.classList.remove("hidden");
    //        mensajeDiv.classList.add(bgColor, "animate-fade-in");

    //        // Ocultar después de 3 segundos con animación de salida
    //        setTimeout(() => {
    //            mensajeDiv.classList.add("animate-fade-out");
    //            setTimeout(() => mensajeDiv.classList.add("hidden"), 500);
    //        }, 3000);
    //    }
    //});
      



        //let successMessage = "@successMessage";
        //let errorMessage = "@errorMessage";

        //if (successMessage.trim() !== "") {
        //    showMessage(successMessage, "success");
        //}
        //else if (errorMessage.trim() !== "") {
        //    showMessage(errorMessage, "error");
        //}

        //function showMessage(msg, type) {
        //    let mensajeDiv = document.getElementById("mensajeVerificacion");
        //    mensajeDiv.textContent = msg;
        //    mensajeDiv.classList.remove("hidden");
        //    mensajeDiv.classList.add(type === "success" ? "bg-green-500" : "bg-red-500", "text-white", "p-2", "rounded");

        //    // Duración de 3 segundos
        //    setTimeout(() => {
        //        mensajeDiv.classList.add("hidden");
        //        mensajeDiv.classList.remove("bg-green-500", "bg-red-500");
        //        mensajeDiv.textContent = "";
        //    }, 3000);
        //}
    });




    //    let mensajeVerificacion = "";
    //    let tipo = "";

    //    mensajeVerificacion = "@successMessage";
    //    if (!mensajeVerificacion) {
    //        mensajeVerificacion = "@errorMessage";
    //        tipo = "error";
    //    } else {
    //        tipo = "success";
    //    }
    //    if (mensajeVerificacion.trim() !== "") {
    //        let mensajeDiv = document.getElementById("mensajeVerificacion");
    //        mensajeDiv.textContent = mensajeVerificacion;
    //        mensajeDiv.classList.remove("hidden");

    //        if (tipo === "success") {
    //            mensajeDiv.classList.add("bg-green-500", "text-white", "p-2", "rounded");
    //        } else {
    //            mensajeDiv.classList.add("bg-red-500", "text-white", "p-2", "rounded");
    //        }
            
    //    }
    //})



