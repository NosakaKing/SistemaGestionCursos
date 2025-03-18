
$().ready(
    () => {
        estudiante()
    }
);

var estudiante = () => {
    var leerEstudiante = new Estudiante()
    leerEstudiante.listaEstudiantes()
}