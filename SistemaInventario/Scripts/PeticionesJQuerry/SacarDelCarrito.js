﻿function SacarDelCarrito(id) {
        $.ajax({
            url: '/Carrito/EliminarElementoDeLaLista?id=' + id,
            type: 'POST',
            async: true,
            data: '',
            success: function (resultado) {
                if (resultado == true) {
                    alertify.success('Producto Eliminado de tu coleccion');
                    window.location.reload(true);
                }
            }

        });

    }