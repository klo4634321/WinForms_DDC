# get_brightness.py
# import screen_brightness_control as sbc

# try:
#     brightness = sbc.get_brightness()[0]
#     print(brightness)
# except Exception as e:
#     print(f"錯誤：{e}")


from monitorcontrol import get_monitors

for monitor in get_monitors():
    with monitor:
        print(monitor.get_luminance())