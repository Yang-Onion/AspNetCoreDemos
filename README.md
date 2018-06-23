# AspNetCoreDemos
## openssl 生成pfx文件命令
```
openssl req -newkey rsa:2048 -nodes -keyout orderservice.key -x509 -days 365 -out orderservice.cer

openssl pkcs12 -export -in orderservice.cer -inkey orderservice.key -out orderservice.pfx
```

