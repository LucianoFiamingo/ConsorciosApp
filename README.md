# Tercer Clase de Práctica "Intro A MVC"

El objetivo es que puedan armar un **ABM de Alimentos** donde:
**Alimento** tiene
Id -> int
Nombre -> string
Peso -> int

### Aclaraciones
1. Crear un Fork de este repositorio y luego clonarlo localmente (recomendable hacer commits y pushes luego de cada funcionalidad que prueban que funciona)
2. Dividir la solucion en 3 capas fisicas **IntroMVC** (web), **Servicios** (biblioteca de clases) y **Entidades** (biblioteca de clases)
3. Deben utilizar una lista estática en la clase **AlimentosServicio.cs** o AlimentosRepositorio.cs (Aquellos que conozcan el patron repository)
4. Crear el controller **AlimentosController.cs** en la carpeta /Controllers con las acciones
	1. **Alta:**  con su respectiva vista /Views/Alimentos/Alta.cshtml
	2. **Todos:**  con su respectiva vista /Views/Alimentos/Todos.cshtml con links a Alta y Editar
	3. **Editar:**  con su respectiva vista /Views/Alimentos/Editar.cshtml
	4. **Borrar**
5. Hacer Commit y Push de todo a su fork.
