import zeep
from requests import Session
from zeep.transports import Transport

# Configuración de la sesión para deshabilitar SSL
session = Session()
session.verify = False  # Desactiva la verificación SSL
transport = Transport(session=session)

# URL del WSDL (Actualiza el puerto si es necesario)
wsdl = 'http://localhost:60724/Service1.svc?wsdl'
client = zeep.Client(wsdl=wsdl, transport=transport)

# Funciones para categorías
def crear_categoria():
    try:
        category_data = {
            "CategoryName": input("Nombre de la categoría: "),
            "Description": input("Descripción de la categoría: ")
        }
        response = client.service.CreateCategory(category_data)
        if response:
            print(f"Categoría creada exitosamente: ID {response.CategoryID}, Nombre: {response.CategoryName}")
        else:
            print("No se pudo crear la categoría.")
    except Exception as e:
        print(f"Error al crear la categoría: {e}")

def actualizar_categoria():
    try:
        category_to_update = {
            "CategoryID": int(input("ID de la categoría a actualizar: ")),
            "CategoryName": input("Nuevo nombre de la categoría: "),
            "Description": input("Nueva descripción: ")
        }
        response = client.service.UpdateCategory(category_to_update)
        if response:
            print("Categoría actualizada exitosamente.")
        else:
            print("No se pudo actualizar la categoría.")
    except Exception as e:
        print(f"Error al actualizar la categoría: {e}")

def eliminar_categoria():
    try:
        category_id = int(input("ID de la categoría a eliminar: "))
        confirm = input(f"¿Estás seguro de que deseas eliminar la categoría con ID {category_id}? (s/n): ").lower()
        if confirm == 's':
            response = client.service.DeleteCategory(category_id)
            if response:
                print("Categoría eliminada exitosamente.")
            else:
                print("No se pudo eliminar la categoría. Verifica si tiene dependencias.")
        else:
            print("Operación cancelada.")
    except Exception as e:
        print(f"Error al eliminar la categoría: {e}")

def listar_categorias():
    try:
        response = client.service.GetAllCategories()
        if response:
            print("Lista de Categorías:")
            for categoria in response:
                print(f"ID: {categoria.CategoryID}, Nombre: {categoria.CategoryName}, Descripción: {categoria.Description}")
        else:
            print("No se encontraron categorías.")
    except Exception as e:
        print(f"Error al obtener la lista de categorías: {e}")

# Funciones para productos
def crear_producto():
    try:
        product = {
            "ProductID": int(input("ID del producto: ")),
            "ProductName": input("Nombre del producto: "),
            "CategoryID": int(input("ID de la categoría: ")),
            "UnitPrice": float(input("Precio unitario: ")),
            "UnitsInStock": int(input("Unidades en stock: "))
        }
        response = client.service.Create(product)
        print(f"Producto creado exitosamente: ID {response.ProductID}, Nombre: {response.ProductName}")
    except Exception as e:
        print(f"Error al crear el producto: {e}")

def actualizar_producto():
    try:
        product_to_update = {
            "ProductID": int(input("ID del producto a actualizar: ")),
            "ProductName": input("Nuevo nombre del producto: "),
            "CategoryID": int(input("Nueva categoría ID: ")),
            "UnitPrice": float(input("Nuevo precio unitario: ")),
            "UnitsInStock": int(input("Nuevo número de unidades en stock: "))
        }
        response = client.service.UpdateProduct(product_to_update)
        if response:
            print(f"Producto con ID {product_to_update['ProductID']} actualizado exitosamente.")
        else:
            print("No se pudo actualizar el producto.")
    except Exception as e:
        print(f"Error al actualizar el producto: {e}")

def eliminar_producto():
    try:
        product_id = int(input("ID del producto a eliminar: "))
        confirm = input(f"¿Estás seguro de que deseas eliminar el producto con ID {product_id}? (s/n): ").lower()
        if confirm == 's':
            response = client.service.DeleteProduct(product_id)
            if response:
                print(f"Producto con ID {product_id} eliminado exitosamente.")
            else:
                print(f"No se pudo eliminar el producto con ID {product_id}. Verifica si existe o si tiene dependencias.")
        else:
            print("Operación cancelada.")
    except Exception as e:
        print(f"Error al eliminar el producto: {e}")

def listar_productos():
    try:
        response = client.service.GetAllProducts()
        if response:
            print("Lista de Productos:")
            for producto in response:
                print(f"ID: {producto.ProductID}, Nombre: {producto.ProductName}, "
                      f"Categoría: {producto.CategoryID}, Precio: {producto.UnitPrice}, Stock: {producto.UnitsInStock}")
        else:
            print("No se encontraron productos.")
    except Exception as e:
        print(f"Error al obtener la lista de productos: {e}")



# Menús para la interacción
def menu_principal():
    while True:
        print("\nMenú Principal:")
        print("1. Gestionar Categorías")
        print("2. Gestionar Productos")
        print("3. Salir")
        opcion = input("Elige una opción: ")

        if opcion == '1':
            menu_categorias()
        elif opcion == '2':
            menu_productos()
        elif opcion == '3':
            print("Saliendo del programa...")
            break
        else:
            print("Opción no válida. Intenta de nuevo.")

def menu_categorias():
    while True:
        print("\nGestión de Categorías:")
        print("1. Crear Categoría")
        print("2. Actualizar Categoría")
        print("3. Eliminar Categoría")
        print("4. Listar Categorías")
        print("5. Volver al Menú Principal")
        opcion = input("Elige una opción: ")

        if opcion == '1':
            crear_categoria()
        elif opcion == '2':
            actualizar_categoria()
        elif opcion == '3':
            eliminar_categoria()
        elif opcion == '4':
            listar_categorias()
        elif opcion == '5':
            break
        else:
            print("Opción no válida. Intenta de nuevo.")

def menu_productos():
    while True:
        print("\nGestión de Productos:")
        print("1. Crear Producto")
        print("2. Actualizar Producto")
        print("3. Eliminar Producto")
        print("4. Listar Productos")
        print("5. Volver al Menú Principal")
        opcion = input("Elige una opción: ")

        if opcion == '1':
            crear_producto()
        elif opcion == '2':
            actualizar_producto()
        elif opcion == '3':
            eliminar_producto()
        elif opcion == '4':
            listar_productos()
        elif opcion == '5':
            break
        else:
            print("Opción no válida. Intenta de nuevo.")

# Ejecutar el menú principal
if __name__ == "__main__":
    menu_principal()
