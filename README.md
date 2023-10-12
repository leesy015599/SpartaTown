# SpartaTown

## 프로젝트 소개
* 내일배움캠프 Unity 게임개발 심화 개인과제
* A08 이소이

## 클래스 구조 및 설명

### 1. PlayerEventController
* 플레이어의 이동, 바라보는 방향을 이벤트로 핸들링합니다.

### 2. PlayerInputController : PlayerEventController
* 1.번의 PlayerEventController 클래스를 상속받습니다.
* InputValue 패키지를 활용해서 키보드 또는 마우스 입력을 받아 정보를 가공합니다. 이벤트 호출 전 정보를 세팅하기 위함입니다.

  ##### 1) OnMove(InputValue value) 메소드
  * 키보드 WASD 인풋에 의해 반환된 Vector2 값으로 플레이어의 이동방향을 설정해줍니다.
  * 벡터의 크기를 normalize해서 일정한 속도로 유지시킵니다.

  ##### 2) OnLook(InputValue value) 메소드
  * 마우스 Position 인풋에 의해 반한된 Vector2 값으로 플레이어가 바라보는 방향을 설정해줍니다.
  * 우선 해당 값을 게임 내 좌표계로 변환시키고, 플레이어 좌표를 중심으로 한번 더 변환시킵니다.

### 3. PlayerMovement
* 플레이어의 이동에 관한 클래스

##### 1) Move(Vector2 direction) 메소드
  * 이 메소드는 OnMoveEvent에 추가됩니다.
  * 2.-1)번 메소드에서 가공된 정보를 매개변수로 이벤트를 호출하는데, 이 때 정보가 Move의 매개변수입니다.
  * 해당 방향으로 rigidbody의 속도를 조절해줍니다.

### 4. PlayerDirection
* 플레이어가 바라보는 방향에 관한 클래스

  ##### 1) LookOpposite(Vector2 direction) 메소드
  * 마우스가 플레이어 좌표를 기준으로 매개변수 `direction`의 방향에 있을 때, 그 각도를 계산해서 스프라이트의 좌우반전 여부를 결정합니다.
  * 플레이어의 스프라이트는 기본적으로 우측을 보고 있습니다 (-90도 < 마우스방향 < 90도)
  * 만약 마우스 방향이 90도를 넘어가면 `SpriteRenderer` 의 flipX를 On으로 바꿔 좌우반전해서 표시합니다.

### 5. CameraMovement
* 카메라의 이동에 관한 클래스
* `FollowPlayer(GameObject player)` 메소드로 플레이어의 좌표를 받아서 카메라의 `position`에 적용합니다.

### 6. NPCDisplay
* NPC가 화면에 표시되는 방법에 관한 클래스

  ##### 1) LookPlayer 메소드
  * NPC가 언제나 플레이어쪽을 바라보도록 합니다.
  * 플레이어의 x좌표와 NPC의 x좌표를 비교해서 스프라이트의 좌우반전 여부를 결정합니다.

  ##### 2) BehindPlayer 메소드
  * 플레이어가 NPC보다 앞에 있을 때 스프라이트가 위에 위치하도록, 뒤에 있을 때는 반대로 뒤에 위치하도록 OrderInLayer 값을 조절합니다.
