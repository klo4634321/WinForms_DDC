# set_brightness.py
import sys
# import screen_brightness_control as sbc

# try:
#     level = int(sys.argv[1])
#     sbc.set_brightness(level)
# except Exception as e:
#     print("error:", e)


from monitorcontrol import get_monitors
try:
    level = int(sys.argv[1])
    for monitor in get_monitors():
        with monitor:
            monitor.set_luminance(level)
except Exception as e:
     print("error:", e)
