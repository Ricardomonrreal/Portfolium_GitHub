# Ricardo Monrreal Pool
# 16 de octubre de 2024 
# # Algoritmo Kruskal apto para las redes de suministro de energía de ciudades

import networkx as nx
import matplotlib.pyplot as plt
import imageio  
import os
import subprocess
import platform

def crear_grafo():
    G = nx.Graph()

    nodos = ["Cancún", "Chetumal", "Bonfil", "Tulum", "Playa del Carmen", "Leona Vicario", "Lázaro Cárdenas"]
    G.add_nodes_from(nodos)
    edges = [
        ("Cancún", "Chetumal", 3),
        ("Cancún", "Bonfil", 6),
        ("Chetumal", "Bonfil", 1),
        ("Chetumal", "Tulum", 2),
        ("Bonfil", "Playa del Carmen", 5),
        ("Playa del Carmen", "Leona Vicario", 1),
        ("Leona Vicario", "Cancún", 11),
        ("Bonfil", "Tulum", 2),
        ("Lázaro Cárdenas", "Leona Vicario", 9),
    ]
    for edge in edges:
        G.add_edge(edge[0], edge[1], weight=edge[2])

    return G, edges

def draw_graph(G, mst_edges, step, pos, total_weight):
    plt.clf()

    nx.draw_networkx_nodes(G, pos, node_size=200, node_color='yellow')
    nx.draw_networkx_labels(G, pos, font_size=8)
    nx.draw_networkx_edges(G, pos, edgelist=G.edges(), edge_color='gray', width=1)
    nx.draw_networkx_edges(G, pos, edgelist=mst_edges, edge_color='red', width=2)

    edge_labels = nx.get_edge_attributes(G, 'weight')
    nx.draw_networkx_edge_labels(G, pos, edge_labels=edge_labels)

    plt.suptitle(f"Paso {step}")
    plt.title(f"Peso Total: {total_weight}", fontsize=9)
    plt.savefig(f"step_{step}.png")
    plt.close()

def kruskal(graph, G):
    graph = sorted(graph, key=lambda x: x[2])
    mst = []
    sets = {v: v for v in G.nodes()}
    total_weight = 0  # Inicializa el peso total

    def find(v):
        if sets[v] != v:
            sets[v] = find(sets[v])
        return sets[v]

    def union(v1, v2):
        sets[find(v1)] = find(v2)

    pos = nx.spectral_layout(G)
    draw_graph(G, [], 0, pos, 0)  # Peso inicial es 0

    step = 1
    for u, v, w in graph:
        if find(u) != find(v):
            mst.append((u, v))
            union(u, v)
            total_weight += w  # Suma el peso de la arista al total
            draw_graph(G, mst, step, pos, total_weight)
            step += 1

    return mst, total_weight

# Limpiar cualquier imagen previa
for file in os.listdir():
    if file.startswith("step_") and file.endswith(".png"):
        os.remove(file)

G, edges = crear_grafo()

mst, total_weight = kruskal(edges, G)

# Crear el GIF
gif_filename = 'kruskal_animation.gif'
with imageio.get_writer(gif_filename, mode='I', duration=1000) as writer:  # 1 segundo entre pasos
    for step in range(len(mst) + 1):
        filename = f"step_{step}.png"
        if os.path.exists(filename):
            writer.append_data(imageio.v2.imread(filename))
        else:
            print(f"Archivo no encontrado: {filename}")


# Intentar abrir el archivo dependiendo del sistema operativo
if platform.system() == "Windows":
    os.startfile(gif_filename)  # Para Windows
elif platform.system() == "Darwin":
    subprocess.call(('open', gif_filename))  # Para macOS
else:
    subprocess.call(('xdg-open', gif_filename))  # Para Linux

# Eliminar las imágenes temporales después de crear el GIF
for step in range(len(mst) + 1):
    filename = f"step_{step}.png"
    if os.path.exists(filename):
        os.remove(filename)
