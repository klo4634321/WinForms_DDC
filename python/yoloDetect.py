from flask import Flask, Response
import mss
import numpy as np
import cv2
import torch
from PIL import Image
import os


app = Flask(__name__)

# 獲取當前目錄
current_dir = os.path.dirname(os.path.realpath(__file__))

# 使用 os.path.join 動態構建模型的完整路徑
model_path = os.path.join(current_dir, 'runs', 'train', 'my_yolo_model', 'weights', 'best.pt')

# 加載 YOLO 模型
model = torch.hub.load('ultralytics/yolov5', 'custom', path=model_path)

#model = torch.hub.load('ultralytics/yolov5', 'custom', path='C:/Users/user/Desktop/Github/WinForms_DDC/WinForms_DDC/python/runs/train/my_yolo_model/weights/best.pt')
model.conf = 0.25

@app.route('/detect', methods=['GET'])
def detect():
    with mss.mss() as sct:
        monitor = sct.monitors[1]
        img = np.array(sct.grab(monitor))

    # Convert to RGB and PIL
    img_rgb = cv2.cvtColor(img[:, :, :3], cv2.COLOR_BGR2RGB)
    pil_img = Image.fromarray(img_rgb)

    # YOLOv5 推論
    results = model(pil_img)
    detections = results.pandas().xyxy[0].to_dict(orient="records")

    # 畫框
    img_draw = img[:, :, :3].copy()
    for d in detections:
        x1, y1, x2, y2 = map(int, [d["xmin"], d["ymin"], d["xmax"], d["ymax"]])
        label = f"{d['name']} {d['confidence']:.2f}"
        cv2.rectangle(img_draw, (x1, y1), (x2, y2), (0, 0, 255), 2)
        cv2.putText(img_draw, label, (x1, y1 - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.6, (0, 0, 255), 2)

    # 編碼為 JPEG
    _, buffer = cv2.imencode('.jpg', img_draw)
    return Response(buffer.tobytes(), mimetype='image/jpeg')

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
