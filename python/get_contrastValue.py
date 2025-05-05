from monitorcontrol import get_monitors

for monitor in get_monitors():
    with monitor:
        print(monitor.get_contrast())