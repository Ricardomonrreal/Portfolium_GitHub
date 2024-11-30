import heapq
import matplotlib.pyplot as plt
import networkx as nx
import imageio
import os
import subprocess
import platform

def crear_grafo():
    G = nx.Graph()

    nodos = [
        "Restaurante", "Punto 1", "Punto 2", "Punto 3", "Punto 4",
        "Punto 5", "Punto 6", "Punto 7", "Punto 8", "Punto 9", "Punto 10", "Avenida A", "Avenida B", "Avenida C", "Avenida D", "Avenida E"
    ]
    G.add_nodes_from(nodos)
    edges = [
        ("Restaurante", "Punto 4", 2),
        ("Restaurante", "Avenida C", 6),
        ("Restaurante", "Avenida D", 9),
        ("Restaurante", "Avenida B", 2),
        ("Avenida C", "Punto 10", 2),
        ("Avenida C", "Punto 7", 1),
        ("Avenida D", "Punto 2", 7),
        ("Avenida D", "Avenida E", 3),
        ("Avenida B", "Punto 5", 5),
        ("Avenida B", "Avenida A", 4),
        ("Avenida A", "Punto 9", 6),
        ("Avenida A", "Punto 8", 10),
        ("Avenida A", "Punto 3", 2),
        ("Avenida E", "Punto 7", 3),
        ("Avenida E", "Punto 6", 5),
        ("Punto 4", "Punto 5", 1),
        ("Punto 2", "Punto 3", 1),
    ]
    for edge in edges:
        G.add_edge(edge[0], edge[1], weight=edge[2])

    return G, edges


# Algoritmo de Dijkstra
def dijkstra(graph, start):
    queue = [(0, start)]
    distances = {node: float('infinity') for node in graph}
    distances[start] = 0
    previous_nodes = {node: None for node in graph}

    while queue:
        current_distance, current_node = heapq.heappop(queue)

        if current_distance > distances[current_node]:
            continue

        for neighbor, weight in graph[current_node].items():
            distance = current_distance + weight

            if distance < distances[neighbor]:
                distances[neighbor] = distance
                previous_nodes[neighbor] = current_node
                heapq.heappush(queue, (distance, neighbor))

    return distances, previous_nodes

# Función para reconstruir el camino
def get_shortest_paths(graph, start, delivery_points):
    distances, previous_nodes = dijkstra(graph, start)
    shortest_paths = {}
    for point in delivery_points:
        if point in distances:
            path = []
            current_node = point
            while current_node is not None:
                path.append(current_node)
                current_node = previous_nodes[current_node]
            path.reverse()
            shortest_paths[point] = (distances[point], path)  # Incluye el peso total (distancia)
    return shortest_paths

# Visualización del grafo
def draw_graph(G, shortest_paths, pos):
    plt.figure(figsize=(8, 6))
    nx.draw_networkx_nodes(G, pos, node_size=200, node_color='yellow')
    nx.draw_networkx_labels(G, pos, font_size=10)

    # Dibujar todas las aristas
    nx.draw_networkx_edges(G, pos, edge_color='gray', width=1)

    # Dibujar rutas más cortas
    for point, (distance, path) in shortest_paths.items():
        path_edges = [(path[i], path[i + 1]) for i in range(len(path) - 1)]
        nx.draw_networkx_edges(G, pos, edgelist=path_edges, edge_color='red', width=2)
        
        # Mostrar el peso total de la ruta en el título
        plt.title(f"Ruta más corta a {point} con una distancia de {distance}")

        edge_labels = nx.get_edge_attributes(G, 'weight')
        nx.draw_networkx_edge_labels(G, pos, edge_labels=edge_labels)

        #plt.show()

# Ejecución del código
G_nx, edges = crear_grafo()

# Grafo como diccionario para Dijkstra
graph_dijkstra = {node: {} for node in G_nx.nodes}
for u, v, data in G_nx.edges(data=True):
    graph_dijkstra[u][v] = data['weight']
    graph_dijkstra[v][u] = data['weight']

# Puntos de entrega
delivery_points = ["Punto 2", "Punto 3", "Punto 4", "Punto 5", "Punto 6", "Punto 7", "Punto 8"]

# Calcular rutas más rápidas
shortest_paths = get_shortest_paths(graph_dijkstra, "Restaurante", delivery_points)

pos = {
    "Restaurante": (0, 0),
    "Punto 1": (3, -2),
    "Punto 2": (4, 2),
    "Punto 3": (3, 5),
    "Punto 4": (-3, 0),
    "Punto 5": (-3, 3),
    "Punto 6": (7, 5),
    "Punto 7": (7, -2),
    "Punto 8": (0, 7),
    "Punto 9": (-6, 5),
    "Punto 10": (0, -5),
    "Avenida A": (0,5),
    "Avenida B": (0,3),
    "Avenida C": (0,-2),
    "Avenida D": (4,0),
    "Avenida E": (7,0),
}

# Visualizar el grafo y las rutas
draw_graph(G_nx, shortest_paths, pos)

# Crear GIF de las rutas más cortas
gif_filename = 'shortest_paths_animation.gif'
with imageio.get_writer(gif_filename, mode='I', duration=2000) as writer:
    for point, (distance, path) in shortest_paths.items():
        accumulated_distance = 0
        for i in range(1, len(path)):
            plt.figure(figsize=(8, 6))
            
            nx.draw_networkx_nodes(G_nx, pos, node_size=400, node_color='yellow')
            nx.draw_networkx_labels(G_nx, pos, font_size=5)
            nx.draw_networkx_edges(G_nx, pos, edge_color='gray', width=1)
            path_edges = [(path[j], path[j + 1]) for j in range(i)]
            nx.draw_networkx_edges(G_nx, pos, edgelist=path_edges, edge_color='red', width=2)

            accumulated_distance += G_nx[path[i-1]][path[i]]['weight']

            edge_labels = nx.get_edge_attributes(G_nx, 'weight')
            nx.draw_networkx_edge_labels(G_nx, pos, edge_labels=edge_labels)

            plt.title(f"Paso hacia {point}: Peso acumulado = {accumulated_distance}")

            plt.savefig(f"step_{point}_{i}.png")
            plt.close()

            writer.append_data(imageio.v2.imread(f"step_{point}_{i}.png"))

# Intentar abrir el archivo dependiendo del sistema operativo
if platform.system() == "Windows":
    os.startfile(gif_filename)  # Para Windows
elif platform.system() == "Darwin":
    subprocess.call(('open', gif_filename))  # Para macOS
else:
    subprocess.call(('xdg-open', gif_filename))  # Para Linux

# Eliminar las imágenes temporales después de crear el GIF
for point in delivery_points:
    for i in range(1, len(shortest_paths[point][1])):
        filename = f"step_{point}_{i}.png"
        if os.path.exists(filename):
            os.remove(filename)

print(f"GIF guardado como: {gif_filename}")
