module.exports = {
    content: [
        './Views/**/*.cshtml', // Archivos Razor en las vistas
        './Pages/**/*.razor', // Archivos Razor si tienes componentes en Blazor
        './wwwroot/**/*.js',  // Archivos JS con clases dinámicas
    ],

    darkMode: 'class', // Habilitar el modo oscuro basado en clases
    theme: {
        extend: {
            colors: {
                primary: {
                    "50": "#eff6ff",
                    "100": "#dbeafe",
                    "200": "#bfdbfe",
                    "300": "#93c5fd",
                    "400": "#60a5fa",
                    "500": "#3b82f6",
                    "600": "#2563eb",
                    "700": "#1d4ed8",
                    "800": "#1e40af",
                    "900": "#1e3a8a",
                    "950": "#172554"
                }
            },
            fontFamily: {
                'body': [
                    'Montserrat',
                    'ui-sans-serif',
                    'system-ui',
                    '-apple-system',
                ],
                'sans': [
                    'Montserrat',
                    'ui-sans-serif',
                    'system-ui',
                    '-apple-system',
                    'system-ui',
                    'Segoe UI',
                ]
            }
        },
    },
    plugins: [],
};
