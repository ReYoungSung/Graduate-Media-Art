# Graduate-Media-Art — 활주로

2024 한동대학교 졸업식을 위해 제작한 인터랙티브 미디어 아트 프로젝트입니다. Unity VFX와 OptiTrack 모션캡처를 활용하며, 대형 커브드 스크린 전시 환경을 전제로 합니다.

## 프로젝트 배경

김성은 뉴미디어 아티스트의 강의를 바탕으로 Unity VFX 시스템을 학습하고 전시를 제작했습니다. 관련 작업으로 Unreal Engine 5와 OptiTrack을 활용한 뮤직비디오도 제작했습니다. 이 저장소의 Unity 프로젝트는 `GMA_MediaArtWall/`에 있습니다.

## 팀

EyeCU(컴퓨터그래픽스 연구실) — 이영성, 김유겸

## 개발 환경

| 항목 | 값 |
| --- | --- |
| Unity Editor | **2021.3.9f1** |
| Unity 프로젝트 폴더 | `GMA_MediaArtWall/` |
| 기본 브랜치 | `Master` |

Unity 버전은 [ProjectVersion.txt](GMA_MediaArtWall/ProjectSettings/ProjectVersion.txt)에 기록된 값을 기준으로 합니다.

- OptiTrack 모션캡처 장비 및 추적 공간
- Immersion Pro와 대형 커브드 스크린: 기존 전시 환경 재현용

## 시작하기

```bash
git clone --branch Master https://github.com/ReYoungSung/Graduate-Media-Art.git
```

1. Unity Hub에 위 버전의 Editor를 설치합니다.
2. 저장소 안의 `GMA_MediaArtWall` 폴더를 프로젝트로 추가합니다. 저장소 최상위 폴더와 Unity 프로젝트 폴더는 서로 다릅니다.
3. 최초 임포트와 Package Manager의 패키지 복원을 완료합니다.
4. `Assets/GMA_Project/GMA_BLock_Art_Wall.unity`을 열고 Play를 실행합니다.

빌드에는 블록 아트 씬과 `Assets/GMA_Project/GMA_Text_Art_Wall.unity`가 등록되어 있습니다. 두 씬을 각각 열어 확인할 수 있습니다. 전체 전시 동작은 모션캡처 연결과 현장 디스플레이 설정이 필요합니다.

빌드 구성은 [EditorBuildSettings.asset](GMA_MediaArtWall/ProjectSettings/EditorBuildSettings.asset), 패키지 목록은 [manifest.json](GMA_MediaArtWall/Packages/manifest.json)에서 확인할 수 있습니다. 아래 `Assets/` 경로는 Unity 프로젝트 폴더 기준입니다.

## 주요 폴더

| 경로 | 내용 |
| --- | --- |
| [Assets/GMA_Project/](GMA_MediaArtWall/Assets/GMA_Project/) | 블록·텍스트 아트 씬 |
| [Assets/OptiTrack/](GMA_MediaArtWall/Assets/OptiTrack/) | OptiTrack 연동 구성 |

## 그래픽·오디오 환경

패키지 설정은 HDRP 12.1.7, LASP 2.1.6, LASP VFX 1.0.2를 사용합니다. 최초 임포트 시 패키지 복원을 완료하고, 전시 PC의 그래픽 환경·오디오 입력·추적 데이터 수신을 각각 확인합니다.

## 사용법

### 전시 실행

1. OptiTrack에서 사용할 추적 대상을 설정하고 Unity의 추적 오브젝트가 실제 위치를 따라 움직이는지 확인합니다.
2. 대형 화면의 출력 해상도와 투사 위치를 맞추고 블록 아트 또는 텍스트 아트 씬을 실행합니다.
3. 추적되는 지팡이 오브젝트를 씬의 상호작용 영역에 가져가 화면 반응을 확인합니다.
4. 다음 관람객을 맞을 때 시작 영역을 이용해 작품 상태를 초기화합니다.

### 상호작용과 운영 조작

아래 영역 이름은 `MagicWanding`에 정의된 태그입니다. 현장 표지와의 대응 및 컴포넌트 연결은 사용하는 씬에서 확인합니다.

| 입력·영역 | 반응 |
| --- | --- |
| `StartPoint` 접촉 | VFX 색상을 순환하고 아트 초기화 |
| `A` / `B` / `C` / `D` 영역 접촉 | 연결된 로고 연출 활성화 |
| `ArtTrigger` 접촉 | 반경을 이용한 구체 제거 연출 호출 |
| 숫자 키 `1`부터 순서대로 | `ChangeVisualEffectTemplate`이 연결된 오브젝트의 VFX 템플릿 선택 |

영역 접촉은 연속 중복 실행을 막기 위해 0.75초의 대기 시간을 둡니다. 빠르게 연속 접촉했을 때 반응이 없으면 잠시 후 다시 시도합니다. 숫자 키는 Inspector에 등록된 템플릿 개수 범위에서 사용합니다.

### 종료·점검

Editor에서는 Play를 끕니다. 추적 입력이 멈추면 장비 연결과 Unity 수신 상태를 먼저 확인합니다. 코드의 Space 입력은 `Scene2` 전환을 시도하지만 현재 등록된 전시 씬 이름과 다르므로, 전시 전환용 키로 사용하려면 씬 연결을 먼저 수정해야 합니다.

동작 기준: [MagicWanding.cs](GMA_MediaArtWall/Assets/MagicWanding.cs) · [ChangeVisualEffectTemplate.cs](GMA_MediaArtWall/Assets/ChangeVisualEffectTemplate.cs)
