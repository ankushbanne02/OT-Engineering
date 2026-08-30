from pydantic import AliasChoices, BaseModel, ConfigDict, Field
from typing import Optional

class ApiResponse(BaseModel):
    model_config = ConfigDict(populate_by_name=True)

    success: bool = Field(validation_alias=AliasChoices("success", "Success"))
    message: str = Field(validation_alias=AliasChoices("message", "Message"))
    data: Optional[dict] = Field(default=None, validation_alias=AliasChoices("data", "Data"))