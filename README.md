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
