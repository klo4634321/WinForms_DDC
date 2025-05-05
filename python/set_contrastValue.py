from monitorcontrol import get_monitors
import sys

try:
    level = int(sys.argv[1])
    for monitor in get_monitors():
        with monitor:
            monitor.set_contrast(level)
except Exception as e:
     print("error:", e)
