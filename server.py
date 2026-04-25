import socket
import subprocess

HOST = "0.0.0.0" 
PORT = 5005

ACTIONS = {
    "1": "shell input keyevent KEYCODE_HOME",
    "2": "shell input keyevent KEYCODE_BACK",
}

def run_adb(args):
    subprocess.run(["adb"] + args.split())

print(f"Server listening on port {PORT}...")
server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind((HOST, PORT))
server.listen(5)

while True:
    conn, addr = server.accept()
    data = conn.recv(1024).decode().strip()
    print(f"Received: {data} from {addr}")
    if data in ACTIONS:
        run_adb(ACTIONS[data])
    conn.close()