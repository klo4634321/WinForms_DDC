from flask import Flask, Response
import cv2
import mss
import numpy as np

app = Flask(__name__)

def capture_frame():
    with mss.mss() as sct:
        monitor = sct.monitors[1]
        img = sct.grab(monitor)
        frame = np.array(img)

        # resize 成 400x400
        frame = cv2.resize(frame, (400, 400))

        print("Image shape:", frame.shape)  # 應該是 (400, 400, 4)
        # 應該是 (400, 400, 4)
        _, buffer = cv2.imencode('.jpg', frame)
        return buffer.tobytes()
    
@app.route('/')
def index():
    print("Screen Stream Server is running!")
    return "Screen Stream Server is running!"

@app.route('/current')
def current():
    print("Capture current frame")
    try:
        frame = capture_frame()
        return Response(frame, mimetype='image/jpeg')
    except Exception as e:
        print("Capture error:", e)
        return Response(status=500)

if __name__ == "__main__":
    app.run(port=5003, debug=False, threaded=True)
