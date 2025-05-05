import unittest
from unittest.mock import patch
import screen_brightness_control as sbc

class TestBrightnessCheck(unittest.TestCase):
    @patch('screen_brightness_control.list_monitors')
    @patch('screen_brightness_control.get_brightness')

    def test_monitor_brightness(self, mock_get_brightness, mock_list_monitors):
        mock_list_monitors.return_value = ['Monitor 1']
        mock_get_brightness.side_effect = [50]

        brightness = sbc.get_brightness()
        self.assertEqual(brightness, 50)
    
    @patch('screen_brightness_control.list_monitors')
    @patch('screen_brightness_control.get_brightness')
    def test_monitor_brightness_fail(self, mock_get_brightness, mock_list_monitors):
        mock_list_monitors.return_value = ['Monitor X']
        mock_get_brightness.side_effect = Exception("不支援亮度")

        monitors = sbc.list_monitors()
        for m in monitors:
            try:
                brightness = sbc.get_brightness(display=m)
            except Exception as e:
                self.assertEqual(str(e), "不支援亮度")


if __name__ == '__main__':
    unittest.main()
