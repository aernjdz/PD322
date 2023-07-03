import requests

url = "https://programmershouse-api.is-an.app/alerts"

data = requests.get(url=url)
print(data.json())