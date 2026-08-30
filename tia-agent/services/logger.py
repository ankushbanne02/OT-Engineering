from pathlib import Path
from datetime import datetime

LOG_FILE = Path("logs/execution.log")

class Logger:
    @staticmethod
    def log(message):
        timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        line = f"[{timestamp}] {message}\n"
        print(line)
        LOG_FILE.parent.mkdir(exist_ok=True)
        with open(LOG_FILE, "a") as file:
            file.write(line)