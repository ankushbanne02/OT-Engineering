from urllib import response

import requests

from config.settings import settings
from services.logger import Logger

from services.response_handler import ResponseHandler

class WrapperClient:

    def __init__(self):
        self.base_url = settings.WRAPPER_URL

    def _post(self, endpoint, body=None):
        url = f"{self.base_url}{endpoint}"
        Logger.log(f"POST : {url}")

        if body:
            Logger.log(f"Payload : {body}")

        response = requests.post(
            url,
            json=body
        )
        
        response.raise_for_status()
        json_response = response.json()

        print(type(json_response))
        print(json_response)

        return ResponseHandler.handle(
            response.json()
        )
        
        # return response.json()

        # return {
        #     "success": True,
        #     "message": "Wrapper Mock Response"
        # }

        # response = {
        #     "success": True,
        #     "message": "Operation Successful",
        #     "data": body
        # }

        # return ResponseHandler.handle(response)
    
    # Connection
    def connect(self):
        return self._post("/connection/connect")

    def disconnect(self):
        return self._post("/connection/disconnect")

    # Project
    def create_project(self, project_name):
        return self._post(
            "/project/create",
            {
                "projectName": project_name,
                "directory": "C:\\Data\\TIA_Projects"
            }
        )



    def open_project(self, project_path):
        url = f"{self.base_url}/project/open?path={project_path}"
        Logger.log(f"POST : {url}")
        response = requests.post(url)
        response.raise_for_status()
        return ResponseHandler.handle(response.json())

    def save_project(self):
        return self._post("/project/save")

    # PLC

    def create_plc(self, plc_type):
        return self._post(
            "/plc/create",
            {
                "plcType": plc_type,
                "deviceName": "PLC_1"
            }
        )

    # HMI

    def create_hmi(self):
        return self._post(
            "/hmi/create",
            {
                "deviceName": "HMI_1",
                "hmiType": "Basic"
            }
        )

wrapper = WrapperClient()