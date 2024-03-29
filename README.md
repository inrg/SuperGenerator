# SuperGenerator
自定义规则的随机字符串生成工具

✔ [Console](https://github.com/inrg/SuperGenerator/tree/console)

![pic2](https://github.com/inrg/SuperGenerator/blob/master/pic/pic2.jpg?raw=true)



 ✔ [Winform](https://github.com/inrg/SuperGenerator)


![pic1](https://github.com/inrg/SuperGenerator/blob/master/pic/pic1.jpg?raw=true)

### 8位随机密码

```
[A-Za-z0-9!@#$%^&*()_+]{8}
```

### 8位或16位随机密码

```
[A-Za-z0-9!@#$%^&*()_+]{8,16}
```

### 8位到16位随机密码

```
[A-Za-z0-9!@#$%^&*()_+]{8-16}
```

### 必须字母开头

```
[A-Za-z]{1}[A-Za-z0-9!@#$%^&*()_+]{8-16}
```

### 必须大写字母开头

```
[A-Z]{1}[A-Za-z0-9!@#$%^&*()_+]{8-16}
```

### 大写字母ABC开头

```
ABC[A-Za-z0-9!@#$%^&*()_+]{8-16}
```

### 大写字母ABC开头，XYZ结尾

```
ABC[A-Za-z0-9!@#$%^&*()_+]{8-16}XYZ
```

### GUID格式

```
[a-z0-9A-Z]{8}-[a-z0-9A-Z]{4}-[a-z0-9A-Z]{4}-[a-z0-9A-Z]{4}-[a-z0-9A-Z]{12}
```
