
# 비동기 프로그래밍 예제

심심해서 만들어본 비동기 프로그래밍 예제.  

## 1. 비동기  
#### 이미지가 비동기적으로 로딩되므로 스크롤링이 부드럽다.
![Async_AdobeExpress](https://user-images.githubusercontent.com/69672253/178984350-8cce80d6-6186-4fa9-bbc1-6e59380ed1d0.gif)  

## 2. 동기  
#### 이미지가 동기적으로 로딩되므로 보여지는 모든 이미지가 로딩되기 전까지 스크롤 되지 않는다.
![Sync_AdobeExpress](https://user-images.githubusercontent.com/69672253/178983556-b7bcc033-8992-4628-a34d-e81b2c52158a.gif)

## 3. 코루틴  
#### 유니티의 코루틴도 근본적으로 동기 방식이기 때문에 일반적인 동기 방식과 같이 끊김 현상이 발생한다.
![Coroutine_AdobeExpress](https://user-images.githubusercontent.com/69672253/178983545-f28d567b-e2dd-4007-85cc-88cca80c324e.gif)

## 동기 방식의 보이지 않는 부분
![Sycn_Detail_AdobeExpress](https://user-images.githubusercontent.com/69672253/178983551-c9384f9c-5846-4f82-afde-7a6aea159f4c.gif)
