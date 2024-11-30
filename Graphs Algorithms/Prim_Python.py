# Algoritmo de Prim usando Networkx
# Ricardo Monrreal Pool
# 16 de octubre de 2024
# Algoritmo Prim apto para la expansión de red en una ciudad

import networkx as nx
import matplotlib.pyplot as plt
import heapq
import os
import imageio
import subprocess
import platform

def crear_grafo():
    G = nx.Graph()

    nodos = ["Estación Internet", "Reg. 219", "Reg. 227", "Reg. 230", "Reg. 100", "Reg. 95", "Reg. 101", "Reg. 510", "Reg. 92", "Reg. 64"]
    G.add_nodes_from(nodos)
    edges = [
        ("Estación Internet", "Reg. 219", 3),
        ("Estación Internet", "Reg. 227", 6),
        ("Reg. 219", "Reg. 227", 1),
        ("Reg. 219", "Reg. 230", 2),
        ("Reg. 227", "Reg. 100", 5),
        ("Reg. 95", "Estación Internet", 11),
        ("Reg. 227", "Reg. 230", 2),
        ("Reg. 101", "Reg. 95", 9),
        ("Reg. 510", "Reg. 64", 1),
        ("Reg. 92", "Reg. 227", 7),
        ("Estación Internet", "Reg. 64", 4),
        ("Reg. 510", "Reg. 95", 3),
        ("Reg. 92", "Reg. 101", 8),
    ]
    for edge in edges:
        G.add_edge(edge[0], edge[1], weight=edge[2])

    return G, edges

def prim_mst(graph, start_node):
    mst = []
    visited = set([start_node])
    edges = [(weight, start_node, neighbor) for neighbor, weight in graph[start_node].items()]
    heapq.heapify(edges)
    
    G = nx.Graph()
    for node, neighbors in graph.items():
        for neighbor, weight in neighbors.items():
            G.add_edge(node, neighbor, weight=weight)
    
    pos = nx.spring_layout(G)  # Disposición de los nodos
    
    total_weight = 0
    step = 0
    
    draw_graph(G, mst, pos, step, total_weight)
    
    while edges:
        weight, frm, to = heapq.heappop(edges)
        if to not in visited:
            visited.add(to)
            mst.append((frm, to))
            total_weight += weight
            
            step += 1
            draw_graph(G, mst, pos, step, total_weight)
            
            for neighbor, weight in graph[to].items():
                if neighbor not in visited:
                    heapq.heappush(edges, (weight, to, neighbor))

    return mst, total_weight

def draw_graph(G, mst_edges, pos, step, total_weight):
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

G_nx, edges = crear_grafo()

graph = {node: {} for node in G_nx.nodes}
for u, v, data in G_nx.edges(data=True):
    graph[u][v] = data['weight']
    graph[v][u] = data['weight']

# Limpiar imágenes previas
for file in os.listdir():
    if file.startswith("step_") and file.endswith(".png"):
        os.remove(file)

# Ejecutar el algoritmo de Prim desde "Cancún"
mst, total_weight = prim_mst(graph, "Estación Internet")

# Crear el GIF
gif_filename = 'prim_animation.gif'
with imageio.get_writer(gif_filename, mode='I', duration=1000) as writer:
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
