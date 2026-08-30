from models.api_response import ApiResponse
from exceptions.wrapper_exception import WrapperException

class ResponseHandler:
    @staticmethod
    def handle(response):
        api = ApiResponse(**response)
        if not api.success:
            raise WrapperException(api.message)
        return api